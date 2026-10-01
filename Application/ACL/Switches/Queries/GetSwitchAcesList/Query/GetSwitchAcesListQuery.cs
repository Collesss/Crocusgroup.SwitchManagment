using Application.ACL.Switches.Queries.GetSwitchAcesList.Common;
using Application.ACL.Switches.Queries.GetSwitchAcesList.Filter;
using Application.ACL.Switches.Queries.GetSwitchAcesList.Response;
using Application.Common.Query.List;
using MediatR;

namespace Application.ACL.Switches.Queries.GetSwitchAcesList.Query
{
    /// <summary>
    /// Query for get list switch aces.
    /// </summary>
    public class GetSwitchAcesListQuery : CommonListQuery<SwitchAceFilter, SwitchAceSortField>, IRequest<PortAcesListResponse>
    {
    }
}
