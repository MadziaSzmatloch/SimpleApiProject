using MediatR;
using MyNewApi.Application.DTO;
using MyNewApi.Application.Managements.Mappings;
using MyNewApi.Domain;

namespace MyNewApi.Application.Managements.GetProductById
{
    internal class GetProductByIdHandler(IProductRepository productRepository) : IRequestHandler<GetProductByIdRequest, ProductDetailDto>
    {
        private readonly IProductRepository _productRepository = productRepository;

        public async Task<ProductDetailDto> Handle(GetProductByIdRequest request, CancellationToken cancellationToken)
        {
            var product = await _productRepository.GetById(request.Id);
            var mapper = new ProductMapper();
            return mapper.ProductToProductDetailDto(product);
        }
    }
}
