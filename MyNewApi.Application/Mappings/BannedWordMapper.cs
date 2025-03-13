using MyNewApi.Application.DTO;
using MyNewApi.Domain.Entities;
using Riok.Mapperly.Abstractions;

namespace MyNewApi.Application.Mappings
{
    [Mapper]
    public partial class BannedWordMapper
    {
        public partial BannedWordDto BannedWordToBannedWordDto(BannedWord bannedWord);
    }
}
