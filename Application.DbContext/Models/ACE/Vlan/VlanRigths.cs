namespace Application.DbContext.Models.ACE.Vlan
{
    [Flags]
    public enum VlanRigths
    {
        None                = 0b0000_0000,
        View                = 0b0000_0010,
        ConfigureAsAccess   = 0b0000_0100,
        ConfigureAsTrunk    = 0b0000_1000,
    }
}
