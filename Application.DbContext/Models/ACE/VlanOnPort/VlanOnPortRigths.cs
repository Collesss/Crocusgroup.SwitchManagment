namespace Application.DbContext.Models.ACE.VlanOnPort
{
    [Flags]
    public enum VlanOnPortRigths
    {
        ReadAccess  = 0b0000_0001,
        WriteAccess = 0b0000_0010,
        ReadTrunk   = 0b0000_0100,
        WriteTrunk  = 0b0000_1000
    }
}
