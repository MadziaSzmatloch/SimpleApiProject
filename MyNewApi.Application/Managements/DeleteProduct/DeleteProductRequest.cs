using MediatR;

namespace MyNewApi.Application.Managements.DeleteProduct
{
    public record DeleteProductRequest() : IRequest
    {
        public int Id { get; set; }
    }
}
