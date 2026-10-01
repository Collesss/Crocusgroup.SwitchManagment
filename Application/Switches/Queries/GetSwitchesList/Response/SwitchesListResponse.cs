using Application.Common.Query.List;
using Application.Switches.Queries.GetSwitchesList.Common;
using Application.Switches.Queries.GetSwitchesList.Filter;

namespace Application.Switches.Queries.GetSwitchesList.Response
{
    public class SwitchesListResponse : CommonListResponse<SwitchLookupDto, SwitchFilter, SwitchSortField>
    {
    }
}
