using MediatR;
using MyNewApi.Application.DTO;

namespace MyNewApi.Application.Managements.GetAllBannedWords
{

    public record GetAllBannedWordsRequest() : IRequest<IEnumerable<BannedWordDto>>;
}
