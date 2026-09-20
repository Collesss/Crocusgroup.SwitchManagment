using Application.DbContext.Models.ACE.Port;
using Application.DbContext.Models.ACE.Switch;
using Application.DbContext.Models.ACE.Vlan;
using Application.DbContext.Models.ACE.VlanOnPort;

namespace Application.DbContext.Models
{
    public class SwitchEntity : BaseEntity
    {
        public string IpOrName { get; set; }

        public string Location { get; set; }

        public string Description { get; set; }

        public string Handler { get; set; }

        public string Login {  get; set; }

        public string Password { get; set; }

        public string SuperPassword { get; set; }


        public IEnumerable<SwitchAceEntity> SwitchACL { get; set; }

        public IEnumerable<PortAceEntity> PortACL { get; set; }

        public IEnumerable<VlanAceEntity> VlanACL { get; set; }

        public IEnumerable<VlanOnPortAceEntity> VlanOnPortACL { get; set; }
    }
}
