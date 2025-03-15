using MediatR;
using MyNewApi.Application.Exceptions;
using MyNewApi.Domain.Interfaces;

namespace MyNewApi.Application.Managements.DeleteBannedWord
{
    public class DeleteBannedWordHandler(IBannedWordRepository bannedWordRepository) : IRequestHandler<DeleteBannedWordRequest>
    {
        private readonly IBannedWordRepository _bannedWordRepository = bannedWordRepository;

        public async Task Handle(DeleteBannedWordRequest request, CancellationToken cancellationToken)
        {
            var word = await _bannedWordRepository.GetById(request.Word);
            if (word == null)
            {
                throw new NotFoundException($"Word: {request.Word} doesn't exist");
            }

            await _bannedWordRepository.Delete(request.Word);
        }
    }
}
