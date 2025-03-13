using Microsoft.EntityFrameworkCore;
using MyNewApi.Domain.Entities;
using MyNewApi.Domain.Interfaces;

namespace MyNewApi.Infrastructure.Repositories
{
    internal class CategoryRepository(MyApiDbContext myApiDbContext) : ICategoryRepository
    {
        private readonly MyApiDbContext _myApiDbContext = myApiDbContext;
        private readonly DbSet<Category> _categories = myApiDbContext.Categories;

        public Category GetById(Guid id)
        {
            return _categories.FirstOrDefault(c => c.Id == id);
        }
    }
}
