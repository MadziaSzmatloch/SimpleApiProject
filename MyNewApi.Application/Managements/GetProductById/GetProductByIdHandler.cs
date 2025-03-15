using MediatR;
using MyNewApi.Application.DTO;
using MyNewApi.Application.Exceptions;
using MyNewApi.Application.Managements.Mappings;
using MyNewApi.Domain.Interfaces;

namespace MyNewApi.Application.Managements.GetProductById
{
    internal class GetProductByIdHandler(IProductRepository productRepository) : IRequestHandler<GetProductByIdRequest, ProductDetailDto>
    {
        private readonly IProductRepository _productRepository = productRepository;

        public async Task<ProductDetailDto> Handle(GetProductByIdRequest request, CancellationToken cancellationToken)
        {
            var product = await _productRepository.GetById(request.Id);
            if (product == null)
            {
                throw new NotFoundException($"Product with id: {request.Id} doesn't exist");
            }
            var mapper = new ProductMapper();
            return mapper.ProductToProductDetailDto(product);
        }
    }
}
