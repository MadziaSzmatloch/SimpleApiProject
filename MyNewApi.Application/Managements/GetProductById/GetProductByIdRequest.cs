using MediatR;
using MyNewApi.Application.DTO;

namespace MyNewApi.Application.Managements.GetProductById
{
    public record GetProductByIdRequest : IRequest<ProductDetailDto>
    {
        public int Id { get; set; }
    }
}
