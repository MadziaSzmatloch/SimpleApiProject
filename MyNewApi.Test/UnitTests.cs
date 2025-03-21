using FluentAssertions;
using MyNewApi.Application.DTO;
using MyNewApi.Application.Managements.AddProduct;
using Refit;
using System.Net;

namespace MyNewApi.Test
{
    public class UnitTests : IClassFixture<CustomWebApplicationFactory>
    {
        private readonly IMyNewApi _myNewApi;

        public UnitTests(CustomWebApplicationFactory factory)
        {
            var client = factory.CreateClient();
            _myNewApi = RestService.For<IMyNewApi>(client);
        }

        [Fact]
        public async Task GetProducts()
        {
            // Act
            var products = await _myNewApi.GetProducts();

            // Assert
            products.Should().NotBeNull();
            products.Should().BeOfType<List<ProductDto>>();
        }

        [Fact]
        public async Task CreateProduct()
        {
            // Arrange
            var request = new AddProductRequest("phone", 70, 1, Guid.Parse("a7066aad-9e0d-459e-979c-84df0bd87db9"));

            // Act
            var response = await _myNewApi.CreateProduct(request);
            var histories = await _myNewApi.GetProductsHistories();

            // Assert
            response.Content.Should().BeOfType<ProductDetailDto>();
            histories.Should().NotBeNull();
            histories.Should().BeOfType<List<ProductHistoryDto>>();

        }

        [Fact]
        public async Task CreateProduct_WithInvalidCategory()
        {
            // Arrange
            var request = new AddProductRequest("name", 1, 10, Guid.NewGuid());

            // Act
            var response = await _myNewApi.CreateProduct(request);

            // Assert
            response.StatusCode.Should().Be(HttpStatusCode.NotFound);
        }

        [Fact]
        public async Task CreateProduct_WithShortName()
        {
            // Arrange
            var request = new AddProductRequest("n", 100, 10, Guid.Parse("a7066aad-9e0d-459e-979c-84df0bd87db9"));

            // Act
            var response = await _myNewApi.CreateProduct(request);

            // Assert
            response.StatusCode.Should().Be(HttpStatusCode.BadRequest);
        }

        [Fact]
        public async Task CreateProduct_WithLongName()
        {
            // Arrange
            var request = new AddProductRequest("nanananananananananananananananananana", 100, 10, Guid.Parse("a7066aad-9e0d-459e-979c-84df0bd87db9"));

            // Act
            var response = await _myNewApi.CreateProduct(request);

            // Assert
            response.StatusCode.Should().Be(HttpStatusCode.BadRequest);
        }

        [Fact]
        public async Task CreateProduct_WithInvalidName()
        {
            // Arrange
            var request = new AddProductRequest("phone&*", 100, 10, Guid.Parse("a7066aad-9e0d-459e-979c-84df0bd87db9"));

            // Act
            var response = await _myNewApi.CreateProduct(request);

            // Assert
            response.StatusCode.Should().Be(HttpStatusCode.BadRequest);
        }

        [Fact]
        public async Task CreateProduct_WithRepeatingName()
        {
            // Arrange
            var request = new AddProductRequest("computer", 100, 10, Guid.Parse("a7066aad-9e0d-459e-979c-84df0bd87db9"));

            // Act
            await _myNewApi.CreateProduct(request);
            var response2 = await _myNewApi.CreateProduct(request);

            // Assert
            response2.StatusCode.Should().Be(HttpStatusCode.BadRequest);
        }



        [Fact]
        public async Task CreateProduct_WithLowPrice()
        {
            // Arrange
            var request = new AddProductRequest("name", 1, 10, Guid.Parse("a7066aad-9e0d-459e-979c-84df0bd87db9"));

            // Act
            var response = await _myNewApi.CreateProduct(request);

            // Assert
            response.StatusCode.Should().Be(HttpStatusCode.BadRequest);
        }

        [Fact]
        public async Task CreateProduct_WithHightPrice()
        {
            // Arrange
            var request = new AddProductRequest("name", 1000000, 10, Guid.Parse("a7066aad-9e0d-459e-979c-84df0bd87db9"));

            // Act
            var response = await _myNewApi.CreateProduct(request);

            // Assert
            response.StatusCode.Should().Be(HttpStatusCode.BadRequest);
        }

        [Fact]
        public async Task CreateProduct_WithNegativeQuantity()
        {
            // Arrange
            var request = new AddProductRequest("name", 100, -10, Guid.Parse("a7066aad-9e0d-459e-979c-84df0bd87db9"));

            // Act
            var response = await _myNewApi.CreateProduct(request);

            // Assert
            response.StatusCode.Should().Be(HttpStatusCode.BadRequest);
        }
    }
}