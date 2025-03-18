namespace MyNewApi.Application.DTO
{
    public class ProductHistoryDto
    {
        public Guid Id { get; set; }
        public Guid ProductId { get; set; }
        public string NewName { get; set; }
        public double NewPrice { get; set; }
        public int NewAvailableQuantity { get; set; }
        public Guid NewCategoryId { get; set; }
        public DateTime ModificationTime { get; set; }
    }
}
