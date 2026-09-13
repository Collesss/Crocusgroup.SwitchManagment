namespace Application.Repository.Models.ACE.VlanOnPort
{
    public class VlanOnPortAceDto : BaseAceDto<VlanOnPortRigthsDto>
    {
        public string InterfaceName { get; set; }

        public int VlanId { get; set; }
    }
}
