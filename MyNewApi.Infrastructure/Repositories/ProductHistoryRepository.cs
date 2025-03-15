using Microsoft.EntityFrameworkCore;
using MyNewApi.Domain.Entities;
using MyNewApi.Domain.Interfaces;

namespace MyNewApi.Infrastructure.Repositories
{
    internal class ProductHistoryRepository(MyApiDbContext myApiDbContext) : IProductHistoryRepository
    {
        private readonly MyApiDbContext _myApiDbContext = myApiDbContext;
        private readonly DbSet<ProductHistory> _productHistories = myApiDbContext.ProductHistories;

        public async Task Add(ProductHistory productHistory)
        {
            await _productHistories.AddAsync(productHistory);
            await _myApiDbContext.SaveChangesAsync();
        }
    }
}
