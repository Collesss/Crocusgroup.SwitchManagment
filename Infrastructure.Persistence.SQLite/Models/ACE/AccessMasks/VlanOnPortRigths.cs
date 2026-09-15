namespace Infrastructure.Persistence.SQLite.Models.ACE.AccessMasks
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
