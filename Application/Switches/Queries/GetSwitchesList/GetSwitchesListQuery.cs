using Application.Common.Query.List;
using MediatR;

namespace Application.Switches.Queries.GetSwitchesList
{
    public class GetSwitchesListQuery : CommonListQuery<SwitchFilter, SwitchSortField>, IRequest<SwitchesListResponse>
    {
    }
}
