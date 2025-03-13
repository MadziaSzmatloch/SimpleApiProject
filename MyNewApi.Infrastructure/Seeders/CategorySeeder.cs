using MyNewApi.Domain.Entities;

namespace MyNewApi.Infrastructure.Seeders
{
    public class CategorySeeder(MyApiDbContext dbContext)
    {
        private readonly MyApiDbContext _dbContext = dbContext;

        public async Task Seed()
        {
            if (await _dbContext.Database.CanConnectAsync())
            {
                if (!_dbContext.Categories.Any())
                {
                    var categories = new List<Category>()
                    {
                        new Category()
                        {
                        Name = "Electronics",
                        MinPrice = 50,
                        MaxPrice = 50000,
                        },
                        new Category()
                        {
                        Name = "Books",
                        MinPrice = 5,
                        MaxPrice = 500,
                        },
                        new Category()
                        {
                        Name = "Clothes",
                        MinPrice = 10,
                        MaxPrice = 5000,
                        }
                    };
                    await _dbContext.Categories.AddRangeAsync(categories);
                    await _dbContext.SaveChangesAsync();
                }
            }
        }
    }
}
