using MediatR;
using MyNewApi.Application.DTO;
using MyNewApi.Application.Managements.Mappings;
using MyNewApi.Domain.Interfaces;

namespace MyNewApi.Application.Managements.UpdateProduct
{
    public class UpdateProductHandler(IProductRepository productRepository) : IRequestHandler<UpdateProductRequest, ProductDetailDto>
    {
        private readonly IProductRepository _productRepository = productRepository;

        public async Task<ProductDetailDto> Handle(UpdateProductRequest request, CancellationToken cancellationToken)
        {
            await _productRepository.Update(new Domain.Entities.Product()
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
