using Bookstore.Data;
using Bookstore.Models;

namespace Bookstore.Repositories
{
    public class PublisherRepository : BaseRepository<Publisher>, IPublisherRepository
    {
        public PublisherRepository(BookstoreDbContext context) : base(context)
        {
        }
    }
}
