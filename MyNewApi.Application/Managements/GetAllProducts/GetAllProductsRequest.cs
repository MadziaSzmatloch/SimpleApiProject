using MediatR;
using MyNewApi.Application.DTO;

namespace MyNewApi.Application.Managements.GetAllProducts
{
    public record GetAllProductsRequest() : IRequest<IEnumerable<ProductDto>>;
}
