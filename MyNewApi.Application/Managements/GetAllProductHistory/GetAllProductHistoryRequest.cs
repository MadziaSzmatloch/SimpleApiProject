using MediatR;
using MyNewApi.Application.DTO;

namespace MyNewApi.Application.Managements.GetAllProductHistory
{
    public record GetAllProductHistoryRequest() : IRequest<IEnumerable<ProductHistoryDto>>;
}
