using MyNewApi.Domain.Entities;

namespace MyNewApi.Domain.Interfaces
{
    public interface IBannedWordRepository
    {
        public Task<IEnumerable<BannedWord>> GetAll();
        public Task<BannedWord> GetById(string word);
        public Task Add(string word);
        public Task Delete(string word);
    }
}
