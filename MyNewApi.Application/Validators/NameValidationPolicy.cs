using MyNewApi.Domain.Entities;
using MyNewApi.Domain.Interfaces;
using System.Text.RegularExpressions;

namespace MyNewApi.Application.Validators
{
    internal class NameValidationPolicy(IProductRepository productRepository) : IProductValidationPolicy
    {
        private readonly IProductRepository _productRepository = productRepository;

        public void Validate(Product product)
        {
            if (string.IsNullOrWhiteSpace(product.Name) || product.Name.Length < 3 || product.Name.Length > 20)
                throw new ArgumentException("Name must be between 3 and 20 characters.");

            if (!Regex.IsMatch(product.Name, "^[a-zA-Z0-9]+$"))
                throw new ArgumentException("Name can only contain letters and numbers.");

            if (_productRepository.ExistsByName(product.Name))
                throw new ArgumentException("Name must be unique.");
        }
    }
}
