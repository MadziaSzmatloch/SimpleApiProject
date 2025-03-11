using MediatR;
using MyNewApi.Application.DTO;
using MyNewApi.Application.Managements.Mappings;
using MyNewApi.Domain.Interfaces;

namespace MyNewApi.Application.Managements.GetAllProducts
{
    public class GetAllProductsHandler(IProductRepository productRepository) : IRequestHandler<GetAllProductsRequest, IEnumerable<ProductDto>>
    {
        private readonly IProductRepository _productRepository = productRepository;

        public async Task<IEnumerable<ProductDto>> Handle(GetAllProductsRequest request, CancellationToken cancellationToken)
        {
            var products = await _productRepository.GetAll();
            var mapper = new ProductMapper();
            return products.Select(mapper.ProductToProductDto).ToList();
        }
    }
}
