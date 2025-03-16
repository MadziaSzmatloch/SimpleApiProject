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
                            Id = Guid.Parse("a7066aad-9e0d-459e-979c-84df0bd87db9"),
                            Name = "Electronics",
                            MinPrice = 50,
                            MaxPrice = 50000,
                        },
                        new Category()
                        {
                            Id = Guid.Parse("2fd470d7-a793-49b4-aa25-eb107bc56bc8"),
                            Name = "Books",
                            MinPrice = 5,
                            MaxPrice = 500,
                        },
                        new Category()
                        {
                            Id = Guid.Parse("0e6b516b-55f6-4c37-84da-61bd433e4397"),
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
