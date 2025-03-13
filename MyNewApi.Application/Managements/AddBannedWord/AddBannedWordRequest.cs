using MediatR;
using MyNewApi.Application.DTO;

namespace MyNewApi.Application.Managements.AddBannedWord
{
    public record AddBannedWordRequest() : IRequest<BannedWordDto>
    {
        public string Word { get; set; } = string.Empty;
    }
}
