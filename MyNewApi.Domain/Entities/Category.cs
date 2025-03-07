namespace MyNewApi.Domain.Entities
{
    public class Category
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public double MinPrice { get; set; }
        public double MaxPrice { get; set; }
    }
}
