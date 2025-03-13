using MyNewApi.Domain.Entities;

namespace MyNewApi.Domain.Interfaces
{
    public interface ICategoryRepository
    {
        public Category GetById(Guid id);
    }
}
