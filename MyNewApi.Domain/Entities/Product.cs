using System.Text.RegularExpressions;

namespace MyNewApi.Domain.Entities
{
    public class Product
    {
        public int Id { get; set; }

        private string _name = string.Empty;
        public double Price { get; set; }
        public int AvailableQuantity { get; set; }
        public int? CategoryId { get; set; }
        public Category? Category { get; set; }

        public string Name
        {
            get => _name;
            set
            {
                if (string.IsNullOrWhiteSpace(value) || value.Length < 3 || value.Length > 20)
                    throw new ArgumentException("Name must be between 3 and 20 characters.");

                if (!Regex.IsMatch(value, "^[a-zA-Z0-9]+$"))
                    throw new ArgumentException("Name can only contain letters and numbers.");

                _name = value;
            }
        }

    }
}
