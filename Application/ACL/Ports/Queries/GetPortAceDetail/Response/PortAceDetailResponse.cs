using Application.ACL.Common;
using Application.ACL.Switches.Common;

namespace Application.ACL.Ports.Queries.GetPortAceDetail.Response
{
    public class PortAceDetailResponse : CommonAceDto<SwitchRightsMask>
    {
        public string InterfaceName { get; set; }
    }
}
