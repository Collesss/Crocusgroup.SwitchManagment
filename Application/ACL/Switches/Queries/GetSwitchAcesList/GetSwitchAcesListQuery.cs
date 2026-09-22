using Application.Common.Query.List;
using MediatR;

namespace Application.ACL.Switches.Queries.GetSwitchAcesList
{
    /// <summary>
    /// Query for get list switch aces.
    /// </summary>
    public class GetSwitchAcesListQuery : CommonListQuery<SwitchAceFilter, SwitchAceSortField>, IRequest<SwitchAcesListResponse>
    {
    }
}
