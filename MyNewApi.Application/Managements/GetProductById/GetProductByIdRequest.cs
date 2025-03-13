using MediatR;
using MyNewApi.Application.DTO;

namespace MyNewApi.Application.Managements.GetProductById
{
    public record GetProductByIdRequest : IRequest<ProductDetailDto>
    {
        public Guid Id { get; set; }
    }
}
