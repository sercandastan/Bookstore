using Bookstore.Data;
using Bookstore.Models;
using Bookstore.Models.DTOs.Category;

namespace Bookstore.Repositories
{
    public class CategoryRepository : BaseRepository<Category>, ICategoryRepository
    {


        public CategoryRepository(BookstoreDbContext context) : base(context)
        {

        }


    }
}
