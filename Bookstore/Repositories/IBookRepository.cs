using Bookstore.Models;
using Bookstore.Models.DTOs.Book;

namespace Bookstore.Repositories
{
    public interface IBookRepository : IBaseRepository<Book>
    {
       public Task<IEnumerable<Book>> GetAllBooksWithIncludesAsync();

       public Task<Book?> GetBookByIdWithIncludesAsync(int id);

       public Task<bool> UpdateBookWithAuthorsAsync(UpdateBook_DTO updateDto);



    }
}
