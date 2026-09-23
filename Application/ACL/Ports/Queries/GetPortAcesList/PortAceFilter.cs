using Application.ACL.Common;

namespace Application.ACL.Ports.Queries.GetPortAcesList
{
    public class PortAceFilter : CommonAceFilter
    {
        public string SearchByIntefaceName { get; set; }
    }
}
