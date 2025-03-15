using MyNewApi.Application.Exceptions;
using MyNewApi.Domain.Entities;
using MyNewApi.Domain.Interfaces;

namespace MyNewApi.Application.Validators
{
    internal class PriceValidationPolicy(ICategoryRepository categoryRepository) : IProductValidationPolicy
    {
        private readonly ICategoryRepository _categoryRepository = categoryRepository;

        public void Validate(Product product)
        {
            product.Category ??= _categoryRepository.GetById(product.CategoryId);

            if (product.Category == null)
                throw new ValidationException("There is no category with given id");


            if (product.Price < product.Category.MinPrice || product.Price > product.Category.MaxPrice)
                throw new ValidationException($"Price must be between {product.Category.MinPrice} and {product.Category.MaxPrice}.");
        }
    }
}
