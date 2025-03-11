using MyNewApi.Domain.Entities;

namespace MyNewApi.Application.Validators
{
    public class ProductValidator(IEnumerable<IProductValidationPolicy> policies)
    {
        private readonly IEnumerable<IProductValidationPolicy> _policies = policies;

        public void Validate(Product product)
        {
            foreach (var policy in _policies)
            {
                policy.Validate(product);
            }
        }
    }
}
