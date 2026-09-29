using Application.ACL.Common.Filter;

namespace Application.ACL.Ports.Queries.GetPortAcesList
{
    public class PortAceFilter : CommonAceFilter
    {
        public string SearchByIntefaceName { get; set; }
    }
}
