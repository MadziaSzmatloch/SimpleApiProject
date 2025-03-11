using MyNewApi.Domain.Entities;

namespace MyNewApi.Application.Validators
{
    public interface IProductValidationPolicy
    {
        void Validate(Product product);
    }
}
