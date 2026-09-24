namespace Application.Switches.Queries.GetSwitchDetail.Port
{
    public class VlanOnPort
    {
        public int VlanId { get; set; }

        public bool IsSet {  get; set; }

        public bool CanSetAsAccess { get; set; }

        public bool CanSetAsTrunk { get; set; }
    }
}