using Application.ACL.Common.Filter;

namespace Application.ACL.Vlans.Queries.GetVlanAcesList.Filter
{
    public class VlanAceFilter : CommonAceFilter
    {
        /// <summary>
        /// Filter By VlanId, be great than 0 or null.
        /// </summary>
        public int? VlanId { get; set; }
    }
}
