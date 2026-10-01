using Application.ACL.Common.Filter;
using Application.DbContext.Models.ACE.Vlan;

namespace Application.ACL.Vlans.Queries.GetVlanAcesList.Filter
{
    public class VlanAceFilterApplier : CommonAceFilterApplier<VlanAceFilter, VlanAceEntity, VlanRigths>
    {
        public override IQueryable<VlanAceEntity> ApplyFilter(VlanAceFilter filter, IQueryable<VlanAceEntity> entities)
        {
            var query = base.ApplyFilter(filter, entities);

            if (filter.VlanId is not null)
                query = query.Where(vlanAce => vlanAce.VlanId == filter.VlanId);

            return query;
        }
    }
}
