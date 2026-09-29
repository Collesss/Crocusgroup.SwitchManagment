using Application.Common.Query.Detail;
using MediatR;

namespace Application.ACL.Switches.Queries.GetSwitchAceDetail
{
    /// <summary>
    /// Query for get detail switch ace by Id.
    /// </summary>
    public class GetSwitchAceDetailQuery : CommonDetailQuery, IRequest<SwitchAceDetailResponse>
    {
    }
}