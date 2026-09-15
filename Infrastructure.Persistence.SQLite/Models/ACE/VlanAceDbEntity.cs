using Infrastructure.Persistence.SQLite.Models.ACE.AccessMasks;

namespace Infrastructure.Persistence.SQLite.Models.ACE
{
    public class VlanAceDbEntity : BaseAceDbEntity<VlanRigths>
    {
        public int VlanId { get; set; }
    }
}
