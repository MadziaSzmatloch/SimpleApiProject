using MediatR;
using MyNewApi.Application.DTO;
using MyNewApi.Application.Managements.Mappings;
using MyNewApi.Domain;

namespace MyNewApi.Application.Managements.AddProduct
{
    public class AddProductHandler(IProductRepository productRepository) : IRequestHandler<AddProductRequest, ProductDetailDto>
    {
        private readonly IProductRepository _productRepository = productRepository;

        public async Task<ProductDetailDto> Handle(AddProductRequest request, CancellationToken cancellationToken)
        {
            await _productRepository.Add(new Domain.Entities.Product()
            {
                Id = request.Id,
                Name = request.Name,
                Price = request.Price,
                AvailableQuantity = request.AvailableQuantity,
                CategoryId = request.CategoryId,
            });

            var product = await _productRepository.GetById(request.Id);
            var mapper = new ProductMapper();
            return mapper.ProductToProductDetailDto(product);
        }
    }
}
