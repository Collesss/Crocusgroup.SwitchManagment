using Application.Common.Interfaces;
using Application.CurrentUserService.Interfaces;
using Application.CurrentUserService.Security;
using Application.DbContext.Models;
using Application.DbContext.Models.ACE.Switch;
using System.Linq.Dynamic.Core;

namespace Application.Switches.Queries.GetSwitchesList
{
    public class SwitchFilterApplier : IFilterApplier<GetSwitchesListQuery, SwitchEntity>
    {
        private readonly ICurrentUserService _currentUserService;

        public SwitchFilterApplier(ICurrentUserService currentUserService) 
        {
            _currentUserService = currentUserService ?? throw new ArgumentNullException(nameof(currentUserService));
        }

        public IQueryable<SwitchEntity> ApplyFilter(GetSwitchesListQuery filter, IQueryable<SwitchEntity> entities)
        {
            ArgumentNullException.ThrowIfNull(filter, nameof(filter));
            ArgumentNullException.ThrowIfNull(entities, nameof(entities));
            
            var notNullAndEmptySearchProps = filter.GetType().GetProperties()
                    .Where(prop => prop.Name.StartsWith("SearchBy") && prop.GetValue(filter) is string str && !string.IsNullOrEmpty(str));

            string filterStr = string.Join(" AND ", notNullAndEmptySearchProps
                .Select((prop, i) => $"{prop.Name.Replace("SearchBy", string.Empty)}.Contains(@{i})"));

            object[] args = notNullAndEmptySearchProps.Select(prop => prop.GetValue(filter)).ToArray();

            entities = entities.Where(filterStr, args);

            if (!_currentUserService.HasPermission(Permissions.Switch.AclBypass))
                entities = entities.Where(@switch => @switch.SwitchACL.Any(switchAce => switchAce.RightsMask.HasFlag(SwitchRights.SummaryView) && _currentUserService.GroupsIds.Contains(switchAce.GroupId)));

            return entities;
        }
    }
}
