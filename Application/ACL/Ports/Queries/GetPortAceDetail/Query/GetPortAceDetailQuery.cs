using Application.ACL.Ports.Queries.GetPortAceDetail.Response;
using Application.Common.Query.Detail;
using MediatR;

namespace Application.ACL.Ports.Queries.GetPortAceDetail.Query
{
    /// <summary>
    /// Query for get detail port ace by Id.
    /// </summary>
    public class GetPortAceDetailQuery : CommonDetailQuery, IRequest<PortAceDetailResponse>
    {
    }
}