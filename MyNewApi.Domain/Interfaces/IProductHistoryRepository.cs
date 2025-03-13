using MyNewApi.Domain.Entities;

namespace MyNewApi.Domain.Interfaces
{
    public interface IProductHistoryRepository
    {
        public Task Add(ProductHistory productHistory);
    }
}
