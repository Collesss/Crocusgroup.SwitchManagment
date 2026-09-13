namespace Application.Repository.Models.ACE.VlanOnPort
{
    [Flags]
    public enum VlanOnPortRigthsDto
    {
        ReadAccess,
        WriteAccess,
        ReadTrunk,
        WriteTrunk
    }
}
