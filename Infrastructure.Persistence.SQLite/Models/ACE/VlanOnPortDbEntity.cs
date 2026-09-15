using Infrastructure.Persistence.SQLite.Models.ACE.AccessMasks;

namespace Infrastructure.Persistence.SQLite.Models.ACE
{
    public class VlanOnPortDbEntity : BaseAceDbEntity<VlanOnPortRigths>
    {
        public string InterfaceName { get; set; }

        public int VlanId { get; set; }
    }
}
