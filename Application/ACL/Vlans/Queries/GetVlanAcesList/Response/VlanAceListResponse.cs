using Application.ACL.Vlans.Queries.GetVlanAcesList.Common;
using Application.ACL.Vlans.Queries.GetVlanAcesList.Filter;
using Application.Common.Query.List;

namespace Application.ACL.Vlans.Queries.GetVlanAcesList.Response
{
    public class VlanAceListResponse : CommonListResponse<VlanAceLookupDto, VlanAceFilter, VlanAceSortField>
    {
    }
}
