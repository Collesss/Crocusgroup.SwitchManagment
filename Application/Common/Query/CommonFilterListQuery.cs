using Microsoft.EntityFrameworkCore;

namespace Application.Common.Query
{
    public abstract class CommonFilterListQuery<TEntity> where TEntity : class
    {
        public abstract IQueryable<TEntity> GetFilter(DbSet<TEntity> dbSet);
    }
}