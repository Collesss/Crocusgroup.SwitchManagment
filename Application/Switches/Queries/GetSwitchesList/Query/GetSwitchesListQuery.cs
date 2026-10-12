using Application.Common.Query.List;
using Application.Switches.Queries.GetSwitchesList.Filter;
using Application.Switches.Queries.GetSwitchesList.Response;
using MediatR;

namespace Application.Switches.Queries.GetSwitchesList.Query
{
    public class GetSwitchesListQuery : CommonListQuery<SwitchFilter>, IRequest<SwitchesListResponse>
    {
    }
}
