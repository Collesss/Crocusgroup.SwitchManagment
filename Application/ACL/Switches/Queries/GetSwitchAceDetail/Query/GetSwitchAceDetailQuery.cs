using Application.ACL.Switches.Queries.GetSwitchAceDetail.Response;
using Application.Common.Query.Detail;
using MediatR;

namespace Application.ACL.Switches.Queries.GetSwitchAceDetail.Query
{
    /// <summary>
    /// Query for get detail switch ace by Id.
    /// </summary>
    public class GetSwitchAceDetailQuery : CommonDetailQuery, IRequest<SwitchAceDetailResponse>
    {
    }
}