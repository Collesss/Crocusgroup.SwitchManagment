namespace Application.DbContext.Models.ACE.VlanOnPort
{
    [Flags]
    public enum VlanOnPortRigths
    {
        ReadAccess,
        WriteAccess,
        ReadTrunk,
        WriteTrunk
    }
}
