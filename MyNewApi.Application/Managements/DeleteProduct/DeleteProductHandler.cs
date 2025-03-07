using MediatR;
using MyNewApi.Domain;

namespace MyNewApi.Application.Managements.DeleteProduct
{
    public class DeleteProductHandler(IProductRepository productRepository) : IRequestHandler<DeleteProductRequest>
    {
        private readonly IProductRepository _productRepository = productRepository;

        public async Task Handle(DeleteProductRequest request, CancellationToken cancellationToken)
        {
            await _productRepository.Delete(request.Id);
        }
    }
}
