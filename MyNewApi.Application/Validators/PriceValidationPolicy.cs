using MyNewApi.Domain.Entities;
using MyNewApi.Domain.Interfaces;

namespace MyNewApi.Application.Validators
{
    internal class PriceValidationPolicy(ICategoryRepository categoryRepository) : IProductValidationPolicy
    {
        private readonly ICategoryRepository _categoryRepository = categoryRepository;

        public void Validate(Product product)
        {
            //if (product.CategoryId == 0)
            //    throw new ArgumentException("Product must have a category assigned.");


            product.Category ??= _categoryRepository.GetById(product.CategoryId);

            if (product.Category == null)
                throw new ArgumentException("There is no category with given id");


            if (product.Price < product.Category.MinPrice || product.Price > product.Category.MaxPrice)
                throw new ArgumentException($"Price must be between {product.Category.MinPrice} and {product.Category.MaxPrice}.");
        }
    }
}
