using Application.Common.Query.List;
using MediatR;

namespace Application.ACL.Ports.Queries.GetPortAcesList
{
    /// <summary>
    /// Query for get list port aces.
    /// </summary>
    public class GetPortAcesListQuery : CommonListQuery<PortAceFilter, PortAceSortField>, IRequest<PortAcesListResponse>
    {
    }
}
