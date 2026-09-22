using Application.Common.Query.Detail;
using MediatR;

namespace Application.Switches.Queries.GetSwitchDetail
{
    /// <summary>
    /// Query for get switch by Id.
    /// </summary>
    public class GetSwitchDetailQuery : CommonDetailQuery, IRequest<SwitchDetailResponse>
    {
    }
}
