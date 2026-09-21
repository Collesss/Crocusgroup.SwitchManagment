using Application.DbContext.Models;

namespace Application.Common.Interfaces
{
    public interface IFilterApplier<TFilter, TEntity>
        where TFilter : class
        where TEntity : BaseEntity
    {
        IQueryable<TEntity> ApplyFilter(TFilter filter, IQueryable<TEntity> entities);
    }
}
