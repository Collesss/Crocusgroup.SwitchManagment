namespace Application.ACL.Switches.Commands.Common
{
    [Flags]
    public enum SwitchRightsMask
    {
        SummaryView = 0b0000_0001,
        DetailView = 0b0000_0010
    }
}
