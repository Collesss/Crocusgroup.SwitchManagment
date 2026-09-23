namespace Application.ACL.Vlans.Common
{
    [Flags]
    public enum VlanRigthsMask
    {
        Listing = 0b0000_0001,
        View = 0b0000_0010
    }
}
