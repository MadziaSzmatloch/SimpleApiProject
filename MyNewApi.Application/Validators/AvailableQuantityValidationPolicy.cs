using MyNewApi.Application.Exceptions;
using MyNewApi.Domain.Entities;

namespace MyNewApi.Application.Validators
{
    internal class AvailableQuantityValidationPolicy : IProductValidationPolicy
    {
        public void Validate(Product product)
        {
            if (product.AvailableQuantity < 0)
                throw new ValidationException("Available quantity cannot be negative.");
        }
    }
}
