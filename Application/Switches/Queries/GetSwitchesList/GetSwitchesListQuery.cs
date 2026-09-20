using Application.Common.Query;
using MediatR;

namespace Application.Switches.Queries.GetSwitchesList
{
    public class GetSwitchesListQuery : CommonListQuery<SwitchFilter, SwitchSortField>, IRequest<SwitchesListResponse>
    {
    }
}
