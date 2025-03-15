using Microsoft.EntityFrameworkCore;
using MyNewApi.Domain.Entities;
using MyNewApi.Domain.Interfaces;

namespace MyNewApi.Infrastructure.Repositories
{
    internal class BannedWordRepository(MyApiDbContext myApiDbContext) : IBannedWordRepository
    {
        private readonly MyApiDbContext _myApiDbContext = myApiDbContext;
        private readonly DbSet<BannedWord> _bannedWoords = myApiDbContext.BannedWords;

        public async Task Add(string word)
        {
            await _bannedWoords.AddAsync(new BannedWord() { Word = word });
            await _myApiDbContext.SaveChangesAsync();
        }

        public async Task Delete(string word)
        {
            var wordToDelete = await _bannedWoords.FirstOrDefaultAsync(x => x.Word == word);
            _bannedWoords.Remove(wordToDelete);
            await _myApiDbContext.SaveChangesAsync();
        }

        public async Task<IEnumerable<BannedWord>> GetAll()
        {
            return await _bannedWoords.ToListAsync();
        }

        public async Task<BannedWord> GetById(string word)
        {
            return await _bannedWoords.FirstOrDefaultAsync(x => x.Word == word);
        }
    }
}
