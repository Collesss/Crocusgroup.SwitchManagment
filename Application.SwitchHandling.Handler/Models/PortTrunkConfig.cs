namespace Application.SwitchHandling.Handler.Models
{
    public sealed class PortTrunkConfig : PortConfig
    {
        public IEnumerable<int> TrunkVlans { get; set; }
    }
}
