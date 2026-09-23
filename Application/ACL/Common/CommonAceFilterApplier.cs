using Application.Common.Interfaces;
using Application.DbContext.Models.ACE;

namespace Application.ACL.Common
{
    public class CommonAceFilterApplier<TFilter, TEntity, TRightsMask> : IFilterApplier<TFilter, TEntity>
        where TFilter : CommonAceFilter
        where TEntity : BaseAceEntity<TRightsMask>
        where TRightsMask : Enum
    {
        public virtual IQueryable<TEntity> ApplyFilter(TFilter filter, IQueryable<TEntity> entities)
        {
            var query = entities;

            if (filter.SwitchId is not null)
                query = query.Where(entity => entity.Id == filter.SwitchId);
            
            if(filter.SearchByGroupId != null)
                query = query.Where(entity => entity.GroupId.Contains(filter.SearchByGroupId));

            return query;
        }
    }
}
