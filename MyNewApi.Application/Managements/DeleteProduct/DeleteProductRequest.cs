using MediatR;

namespace MyNewApi.Application.Managements.DeleteProduct
{
    public record DeleteProductRequest() : IRequest
    {
        public Guid Id { get; set; }
    }
}
