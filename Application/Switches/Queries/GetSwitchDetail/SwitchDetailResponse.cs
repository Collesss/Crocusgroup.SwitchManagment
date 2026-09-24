using Application.Switches.Queries.GetSwitchDetail.Port;

namespace Application.Switches.Queries.GetSwitchDetail
{
    public class SwitchDetailResponse
    {
        public int Id { get; set; }

        public string IpOrName { get; set; }

        public string Location { get; set; }

        public string Description { get; set; }

        public string Handler { get; set; }

        public string Login { get; set; }

        public string Password { get; set; }

        public string SuperPassword { get; set; }

        public IEnumerable<PortDto> Ports { get; set; }

        public IEnumerable<VlanDto> Vlans { get; set; }
    }
}
