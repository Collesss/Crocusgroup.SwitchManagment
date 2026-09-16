namespace Application.DbContext.Models.ACE.VlanOnPort
{
    public class VlanOnPortAceEntity : BaseAceEntity<VlanOnPortRigths>
    {
        public string InterfaceName { get; set; }

        public int VlanId { get; set; }
    }
}
