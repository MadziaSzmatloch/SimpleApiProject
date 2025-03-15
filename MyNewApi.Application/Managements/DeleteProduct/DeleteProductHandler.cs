using MediatR;
using MyNewApi.Application.Exceptions;
using MyNewApi.Domain.Interfaces;

namespace MyNewApi.Application.Managements.DeleteProduct
{
    public class DeleteProductHandler(IProductRepository productRepository) : IRequestHandler<DeleteProductRequest>
    {
        private readonly IProductRepository _productRepository = productRepository;

        public async Task Handle(DeleteProductRequest request, CancellationToken cancellationToken)
        {
            var product = await _productRepository.GetById(request.Id);
            if (product == null)
            {
                throw new NotFoundException($"Product with id: {request.Id} doesn't exist");
            }

            await _productRepository.Delete(request.Id);
        }
    }
}
