using MyNewApi.Application.DTO;
using MyNewApi.Domain.Entities;
using Riok.Mapperly.Abstractions;

namespace MyNewApi.Application.Mappings
{

    [Mapper]
    public partial class ProductHistoryMapper
    {
        public partial ProductHistoryDto ProductHistoryToProductHistoryDto(ProductHistory productHistory);
    }
}
