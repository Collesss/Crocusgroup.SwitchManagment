using Application.ACL.Ports.Queries.GetPortAcesList.Common;
using Application.ACL.Ports.Queries.GetPortAcesList.Filter;
using Application.ACL.Ports.Queries.GetPortAcesList.Response;
using Application.Common.Query.List;
using MediatR;

namespace Application.ACL.Ports.Queries.GetPortAcesList.Query
{
    /// <summary>
    /// Query for get list port aces.
    /// </summary>
    public class GetPortAcesListQuery : CommonListQuery<PortAceFilter, PortAceSortField>, IRequest<PortAcesListResponse>
    {
    }
}
