using MyNewApi.Domain.Entities;

namespace MyNewApi.Infrastructure.Seeders
{
    public class BannedWordsSeeder(MyApiDbContext dbContext)
    {
        private readonly MyApiDbContext _dbContext = dbContext;

        public async Task Seed()
        {
            if (await _dbContext.Database.CanConnectAsync())
            {
                if (!_dbContext.BannedWords.Any())
                {
                    var bannedWords = new List<BannedWord>()
                    {
                        new BannedWord()
                        {
                        Word = "Cake",
                        },
                        new BannedWord()
                        {
                        Word = "One",
                        },
                        new BannedWord()
                        {
                        Word = "Two",
                        }
                    };
                    await _dbContext.BannedWords.AddRangeAsync(bannedWords);
                    await _dbContext.SaveChangesAsync();
                }
            }
        }
    }
}
