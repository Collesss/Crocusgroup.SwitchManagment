namespace Application.Repository.Models.ACE.Vlan
{
    [Flags]
    public enum VlanRigthsDto
    {
        Listing = 0b0000_0001,
        View    = 0b0000_0010
    }
}
