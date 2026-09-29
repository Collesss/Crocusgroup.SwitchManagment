using Application.Common.Query.List;

namespace Application.ACL.Vlans.Queries.GetVlanAcesList
{
    public class VlanAceListResponse : CommonListResponse<VlanAceLookupDto, VlanAceFilter, VlanAceSortField>
    {
    }
}
