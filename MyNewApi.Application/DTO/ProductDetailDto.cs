namespace MyNewApi.Application.DTO
{
    public class ProductDetailDto
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public double Price { get; set; }
        public int AvailableQuantity { get; set; }
    }
}
