using Application.Common.Query.List;

namespace Application.ACL.Switches.Queries.GetSwitchAcesList
{
    public class PortAcesListResponse : CommonListResponse<PortAceLookupDto, SwitchAceFilter, SwitchAceSortField>
    {
    }
}
