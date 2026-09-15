using Infrastructure.Persistence.SQLite.Models.ACE.AccessMasks;

namespace Infrastructure.Persistence.SQLite.Models.ACE
{
    public class PortAceDbEntity : BaseAceDbEntity<PortRights>
    {
        public string InterfaceName { get; set; }
    }
}
