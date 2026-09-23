using Application.ACL.Common;
using Application.ACL.Ports.Common;

namespace Application.ACL.Ports.Queries.GetPortAcesList
{
    public class PortAceLookupDto : CommonAceDto<PortRightsMask>
    {
        public string InterfaceName { get; set; }
    }
}