using Application.Common.Interfaces;
using Application.DbContext.Models.ACE.Switch;

namespace Application.ACL.Switches.Queries.GetSwitchAcesList
{
    public class SwitchAceFilterApplier : IFilterApplier<SwitchAceFilter, SwitchAceEntity>
    {
        public IQueryable<SwitchAceEntity> ApplyFilter(SwitchAceFilter filter, IQueryable<SwitchAceEntity> entities)
        {
            if (filter.SwitchId is not null)
                entities = entities.Where(switchAce => switchAce.Id == filter.SwitchId);

            return entities;
        }
    }
}
