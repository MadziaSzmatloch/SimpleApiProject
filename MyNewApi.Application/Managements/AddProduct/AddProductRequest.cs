using MediatR;
using MyNewApi.Application.DTO;

namespace MyNewApi.Application.Managements.AddProduct
{
    public record AddProductRequest() : IRequest<ProductDetailDto>
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public double Price { get; set; }
        public int AvailableQuantity { get; set; }
        public int CategoryId { get; set; }
    }
}
