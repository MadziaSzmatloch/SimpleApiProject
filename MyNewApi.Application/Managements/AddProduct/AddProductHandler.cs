using MediatR;
using MyNewApi.Application.DTO;
using MyNewApi.Application.Managements.Mappings;
using MyNewApi.Application.Validators;
using MyNewApi.Domain.Entities;
using MyNewApi.Domain.Interfaces;

namespace MyNewApi.Application.Managements.AddProduct
{
    public class AddProductHandler(IProductRepository productRepository, ProductValidator productValidator) : IRequestHandler<AddProductRequest, ProductDetailDto>
    {
        private readonly IProductRepository _productRepository = productRepository;
        private readonly ProductValidator _productValidator = productValidator;

        public async Task<ProductDetailDto> Handle(AddProductRequest request, CancellationToken cancellationToken)
        {
            var product = new Product()
            {
                Name = request.Name,
                Price = request.Price,
                AvailableQuantity = request.AvailableQuantity,
                CategoryId = request.CategoryId,
            };

            _productValidator.Validate(product);
            await _productRepository.Add(product);


            var mapper = new ProductMapper();
            return mapper.ProductToProductDetailDto(product);
        }
    }
}
