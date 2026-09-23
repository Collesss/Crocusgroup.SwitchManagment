using Application.ACL.Common;
using Application.DbContext.Models.ACE.Switch;

namespace Application.ACL.Switches.Queries.GetSwitchAcesList
{
    public class PortAceFilterApplier : CommonAceFilterApplier<SwitchAceFilter, SwitchAceEntity, SwitchRights>
    {
        public override IQueryable<SwitchAceEntity> ApplyFilter(SwitchAceFilter filter, IQueryable<SwitchAceEntity> entities)
        {
            var query = base.ApplyFilter(filter, entities);

            return query;
        }
    }
}
