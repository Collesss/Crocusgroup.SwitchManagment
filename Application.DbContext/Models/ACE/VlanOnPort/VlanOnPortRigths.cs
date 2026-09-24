namespace Application.DbContext.Models.ACE.VlanOnPort
{
    [Flags]
    public enum VlanOnPortRigths
    {
        None        = 0b0000_0000,
        WriteAccess = 0b0000_0010,
        WriteTrunk  = 0b0000_1000
    }
}
