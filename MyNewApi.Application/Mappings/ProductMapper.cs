using MyNewApi.Application.DTO;
using MyNewApi.Domain.Entities;
using Riok.Mapperly.Abstractions;

namespace MyNewApi.Application.Managements.Mappings
{
    [Mapper]
    public partial class ProductMapper
    {
        public partial ProductDto ProductToProductDto(Product product);
        public partial ProductDetailDto ProductToProductDetailDto(Product product);
    }
}
