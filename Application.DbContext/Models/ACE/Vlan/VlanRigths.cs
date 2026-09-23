namespace Application.DbContext.Models.ACE.Vlan
{
    [Flags]
    public enum VlanRigths
    {
        Listing = 0b0000_0001,
        View    = 0b0000_0010
    }
}
