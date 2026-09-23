using Application.ACL.Common;
using Application.DbContext.Models.ACE.Port;

namespace Application.ACL.Ports.Queries.GetPortAcesList
{
    public class PortAceFilterApplier : CommonAceFilterApplier<PortAceFilter, PortAceEntity, PortRights>
    {
        public override IQueryable<PortAceEntity> ApplyFilter(PortAceFilter filter, IQueryable<PortAceEntity> entities)
        {
            var query = base.ApplyFilter(filter, entities);

            if (filter.SwitchId is not null)
                query = query.Where(switchAce => switchAce.Id == filter.SwitchId);

            return query;
        }
    }
}