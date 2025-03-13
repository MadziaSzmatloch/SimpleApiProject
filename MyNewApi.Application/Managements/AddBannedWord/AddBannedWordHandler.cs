using MediatR;
using MyNewApi.Application.DTO;
using MyNewApi.Application.Mappings;
using MyNewApi.Domain.Interfaces;

namespace MyNewApi.Application.Managements.AddBannedWord
{
    public class AddBannedWordHandler(IBannedWordRepository bannedWordRepository) : IRequestHandler<AddBannedWordRequest, BannedWordDto>
    {
        private readonly IBannedWordRepository _bannedWordRepository = bannedWordRepository;

        public async Task<BannedWordDto> Handle(AddBannedWordRequest request, CancellationToken cancellationToken)
        {
            await _bannedWordRepository.Add(request.Word);
            var word = (await _bannedWordRepository.GetAll()).FirstOrDefault(w => w.Word == request.Word);
            var mapper = new BannedWordMapper();
            return mapper.BannedWordToBannedWordDto(word);
        }
    }
}
