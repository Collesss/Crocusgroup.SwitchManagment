using Application.Common.Query.Detail;
using Application.Switches.Queries.GetSwitchDetail.Response;
using MediatR;

namespace Application.Switches.Queries.GetSwitchDetail.Query
{
    /// <summary>
    /// Query for get switch by Id.
    /// </summary>
    public class GetSwitchDetailQuery : CommonDetailQuery, IRequest<SwitchDetailResponse>
    {
    }
}
