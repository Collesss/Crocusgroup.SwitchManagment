using Application.Common.Query.Detail;
using MediatR;

namespace Application.ACL.Ports.Queries.GetPortAceDetail
{
    /// <summary>
    /// Query for get detail port ace by Id.
    /// </summary>
    public class GetPortAceDetailQuery : CommonDetailQuery, IRequest<PortAceDetailResponse>
    {
    }
}