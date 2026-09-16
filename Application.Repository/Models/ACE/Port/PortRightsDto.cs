namespace Application.Repository.Models.ACE.Port
{
    [Flags]
    public enum PortRightsDto : byte
    {
        Listing     = 0b0000_0001,
        View        = 0b0000_0010
    }
}
