using Application.ACL.Common.Filter;

namespace Application.ACL.Vlans.Queries.GetVlanAcesList
{
    public class VlanAceFilter : CommonAceFilter
    {
        public int? VlanId { get; set; }
    }
}
