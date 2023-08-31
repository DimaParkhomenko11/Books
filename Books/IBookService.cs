using System.Collections.Generic;
using System.Threading.Tasks;
using Books.Model;
using MongoDB.Driver;

namespace Books
{
    public interface IBookService
    {
        Task<List<Model.Books>> GetAllAsync();
        Task<Model.Books> GetByIdAsync(string id);
        Task<Model.Books> CreateAsync(Model.Books book);
        Task UpdateAsync(string id, Model.Books book);
        Task DeleteAsync(string id);
    }
}