namespace Application.Switches.Queries.GetSwitchDetail.Port
{
    public class PortDto
    {
        public string InterfaceName { get; set; }

        public string Description { get; set; }

        public PortTypeDto PortType { get; set; }

        public PortStatusDto Status { get; set; }

        public IEnumerable<VlanOnPort> Vlans { get; set; }

        public bool CanConfigureAsAccess { get; set; }
        
        public bool CanConfigureAsTrunk { get; set; }
    }
}
