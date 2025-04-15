using Bookstore.Data;
using Bookstore.Models;

namespace Bookstore.Repositories
{
    public class AuthorRepository : BaseRepository<Author>,IAuthorRepository
    {
        public AuthorRepository(BookstoreDbContext context) : base(context)
        {
        }
    }
}
