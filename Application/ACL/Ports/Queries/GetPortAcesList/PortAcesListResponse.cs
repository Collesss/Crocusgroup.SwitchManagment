using Application.Common.Query.List;

namespace Application.ACL.Ports.Queries.GetPortAcesList
{
    public class PortAcesListResponse : CommonListResponse<PortAceLookupDto, PortAceFilter, PortAceSortField>
    {
    }
}
