namespace Application.SwitchHandling.Handler.Models
{
    public abstract class PortConfig : ConnectConfig
    {
        public string InterfaceName { get; set; }
    }
}
