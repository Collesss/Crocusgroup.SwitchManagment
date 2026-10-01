using Application.ACL.Switches.Queries.GetSwitchAcesList.Common;
using Application.ACL.Switches.Queries.GetSwitchAcesList.Filter;
using Application.Common.Query.List;

namespace Application.ACL.Switches.Queries.GetSwitchAcesList.Response
{
    public class PortAcesListResponse : CommonListResponse<PortAceLookupDto, SwitchAceFilter, SwitchAceSortField>
    {
    }
}
