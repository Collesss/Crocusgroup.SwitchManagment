using Application.ACL.Ports.Queries.GetPortAcesList.Common;
using Application.ACL.Ports.Queries.GetPortAcesList.Filter;
using Application.Common.Query.List;

namespace Application.ACL.Ports.Queries.GetPortAcesList.Response
{
    public class PortAcesListResponse : CommonListResponse<PortAceLookupDto, PortAceFilter, PortAceSortField>
    {
    }
}
