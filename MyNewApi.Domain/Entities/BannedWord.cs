namespace MyNewApi.Domain.Entities
{
    public class BannedWord
    {
        public Guid Id { get; set; }
        public string Word { get; set; } = string.Empty;
    }
}
