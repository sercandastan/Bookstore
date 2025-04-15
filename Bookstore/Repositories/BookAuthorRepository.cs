using Bookstore.Data;
using Bookstore.Models;

namespace Bookstore.Repositories
{
    public class BookAuthorRepository : BaseRepository<BookAuthor>, IBookAuthorRepository
    {
        public BookAuthorRepository(BookstoreDbContext context) : base(context)
        {
        }
    }
}
