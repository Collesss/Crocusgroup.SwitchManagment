namespace Application.SwitchHandling.Handler.Models
{
    public sealed class PortConfigTrunk : PortConfig
    {
        public IEnumerable<int> TrunkVlans { get; set; }
    }
}
