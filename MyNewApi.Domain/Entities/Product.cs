namespace MyNewApi.Domain.Entities
{
    public class Product
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public double Price { get; set; }
        public int AvailableQuantity { get; set; }
        public Guid CategoryId { get; set; }
        public Category Category { get; set; }

    }
}
