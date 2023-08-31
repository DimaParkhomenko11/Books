using System.Collections.Generic;
using System.Threading.Tasks;
using Books.Model;
using Microsoft.Extensions.Options;
using MongoDB.Driver;

namespace Books
{
    public class BookService : IBookService
    {
        private readonly IMongoCollection<Model.Books> _book;
        private readonly BooksConfiguration _settings;
        
        public BookService(IOptions<BooksConfiguration> settings)
        {
            _settings = settings.Value;
            var client = new MongoClient(_settings.ConnectionString);
            var database = client.GetDatabase(_settings.DatabaseName);
            _book = database.GetCollection<Model.Books>(_settings.BooksCollectionName);
        }
        public async Task<List<Model.Books>> GetAllAsync()
        {
            return await _book.Find(c => true).ToListAsync();
        }
        public async Task<Model.Books> GetByIdAsync(string id)
        {
            return await _book.Find<Model.Books>(c => c.id == id).FirstOrDefaultAsync();
        }
        public async Task<Model.Books> CreateAsync(Model.Books book)
        {
            await _book.InsertOneAsync(book);
            return book;
        }
        public async Task UpdateAsync(string id, Model.Books book)
        {
            await _book.ReplaceOneAsync(c => c.id == id, book);
        }
        public async Task DeleteAsync(string id)
        {
            await _book.DeleteOneAsync(c => c.id == id);
        }
    }
}