namespace Application.Ports.Commands.Common
{
    public abstract class CommonConfigurePortCommand
    {
        public int SwitchId { get; set; }

        public string InterfaceName { get; set; }
    }
}
