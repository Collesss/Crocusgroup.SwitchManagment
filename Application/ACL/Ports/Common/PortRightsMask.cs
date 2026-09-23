namespace Application.ACL.Ports.Common
{
    [Flags]
    public enum PortRightsMask
    {
        Listing = 0b0000_0001,
        View    = 0b0000_0010
    }
}
