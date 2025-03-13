using MediatR;
using MyNewApi.Application.DTO;

namespace MyNewApi.Application.Managements.AddProduct
{
    public record AddProductRequest(
        string Name,
        double Price,
        int AvailableQuantity,
        Guid CategoryId
        ) : IRequest<ProductDetailDto>;
}
