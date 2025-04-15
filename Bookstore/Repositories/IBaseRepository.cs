using Microsoft.EntityFrameworkCore.Query;
using System.Linq.Expressions;

namespace Bookstore.Repositories
{
    public interface IBaseRepository<TEntity> where TEntity : class
    {
        public Task<IEnumerable<TEntity>> GetAllAsync();

        public Task<int> AddAsync(TEntity entity);

        public Task<TEntity> FindByIdAsync(int id);

        public Task<bool> DeleteAsync(int id);

        public Task<bool> UpdateAsync(TEntity entity);

        Task<IEnumerable<TResult>> GetFilteredListAsync<TResult>(
Expression<Func<TEntity, TResult>> select,
Expression<Func<TEntity, bool>> where,
Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> orderBy = null,
Func<IQueryable<TEntity>, IIncludableQueryable<TEntity, object>> include = null
);


    }
}
