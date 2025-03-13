using MediatR;
using MyNewApi.Application.DTO;

namespace MyNewApi.Application.Managements.UpdateProduct
{
    public record UpdateProductRequest() : IRequest<ProductDetailDto>
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public double Price { get; set; }
        public int AvailableQuantity { get; set; }
        public Guid CategoryId { get; set; }
    }
}
