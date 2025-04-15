
using System.Linq.Expressions;
using Bookstore.Data;
using Bookstore.Models.Abstract;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Query;

namespace Bookstore.Repositories
{
    public class BaseRepository<TEntity> : IBaseRepository<TEntity> where TEntity : class, IEntity
    {
        protected BookstoreDbContext _context;
        protected DbSet<TEntity> _table;
        public BaseRepository(BookstoreDbContext context)
        {
            _context = context;
            _table = context.Set<TEntity>();
        }
        public async Task<IEnumerable<TEntity>> GetAllAsync()
        {
            return await _table.Where(x => x.Status != Enums.Status.Deleted).ToListAsync();
        }

        public async Task<int> AddAsync(TEntity entity)
        {
            entity.CreatedAt = DateTime.Now;
            entity.Status = Enums.Status.Added;
            var result = await _table.AddAsync(entity);
            await _context.SaveChangesAsync();

            return (int)result.Property(result.Metadata.FindPrimaryKey().Properties.FirstOrDefault()).CurrentValue;
        }
        public async Task<TEntity> FindByIdAsync(int id)
        {
            return await _table.FindAsync(id);
        }

        public async Task<bool> DeleteAsync(int id)
        {
            var entity = await _table.FindAsync(id);

            entity.DeletedAt = DateTime.Now;
            entity.Status = Enums.Status.Deleted;
            _table.Update(entity);

            return await _context.SaveChangesAsync() > 0;
        }

        public async Task<bool> UpdateAsync(TEntity entity)
        {
            _table.Update(entity);
            entity.UpdatedAt = DateTime.Now;
            entity.Status = Enums.Status.Updated;

            return await _context.SaveChangesAsync() > 0 ? true : false;
        }
        //Filtreleme yapılırken kullanılır.
        public async Task<IEnumerable<TResult>> GetFilteredListAsync<TResult>(Expression<Func<TEntity, TResult>> select, Expression<Func<TEntity, bool>> where, Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> orderBy = null, Func<IQueryable<TEntity>, IIncludableQueryable<TEntity, object>> include = null)
        {
            IQueryable<TEntity> query = _table.AsNoTracking();

            if (where != null)
                query = query.Where(where);
            if (include != null)
                query = include(query);

            if (orderBy != null)
                return await orderBy(query).Select(select).ToListAsync();
            else
                return await query.Select(select).ToListAsync();
        }
    }
}
