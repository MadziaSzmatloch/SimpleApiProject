using MediatR;

namespace MyNewApi.Application.Managements.DeleteBannedWord
{
    public record DeleteBannedWordRequest() : IRequest
    {
        public string Word { get; set; } = string.Empty;
    }
}
