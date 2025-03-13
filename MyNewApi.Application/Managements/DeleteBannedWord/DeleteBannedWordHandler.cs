using MediatR;
using MyNewApi.Domain.Interfaces;

namespace MyNewApi.Application.Managements.DeleteBannedWord
{
    public class DeleteBannedWordHandler(IBannedWordRepository bannedWordRepository) : IRequestHandler<DeleteBannedWordRequest>
    {
        private readonly IBannedWordRepository _bannedWordRepository = bannedWordRepository;

        public async Task Handle(DeleteBannedWordRequest request, CancellationToken cancellationToken)
        {
            await _bannedWordRepository.Delete(request.Word);
        }
    }
}
