using MediatR;
using MyNewApi.Application.DTO;
using MyNewApi.Application.Mappings;
using MyNewApi.Domain.Interfaces;

namespace MyNewApi.Application.Managements.GetAllBannedWords
{
    public class GetAllBannedWordsHandler(IBannedWordRepository bannedWordRepository) : IRequestHandler<GetAllBannedWordsRequest, IEnumerable<BannedWordDto>>
    {
        private readonly IBannedWordRepository _bannedWordRepository = bannedWordRepository;

        public async Task<IEnumerable<BannedWordDto>> Handle(GetAllBannedWordsRequest request, CancellationToken cancellationToken)
        {
            var words = await _bannedWordRepository.GetAll();
            var mapper = new BannedWordMapper();
            return words.Select(mapper.BannedWordToBannedWordDto);
        }
    }
}
