using Application.ACL.Common.Filter;

namespace Application.ACL.Ports.Queries.GetPortAcesList.Filter
{
    public class PortAceFilter : CommonAceFilter
    {
        /// <summary>
        /// Filter by InterfaceName, cant be great than 100, apply if not null, empty or contains only whitespace.
        /// </summary>
        public string SearchByIntefaceName { get; set; }
    }
}
