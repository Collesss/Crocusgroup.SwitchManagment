using Application.DbContext.Models;
using Application.DbContext.Models.ACE.Port;
using Application.DbContext.Models.ACE.Switch;
using Application.DbContext.Models.ACE.Vlan;
using Application.DbContext.Models.ACE.VlanOnPort;
using Application.DbContext.Exceptions;
using Microsoft.EntityFrameworkCore;

namespace Application.DbContext
{
    public interface ISwitchManagmentDbContext
    {
        public DbSet<SwitchEntity> Switches { get; set; }

        public DbSet<SwitchAceEntity> SwitchesACL { get; set; }

        public DbSet<PortAceEntity> PortsACL { get; set; }

        public DbSet<VlanAceEntity> VlansACL { get; set; }

        public DbSet<VlanOnPortAceEntity> VlanOnPortACL { get; set; }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="cancellationToken"></param>
        /// <exception cref="DbContextException"></exception>
        /// <returns></returns>
        public abstract Task<int> SaveChangesAsync(CancellationToken cancellationToken);
    }
}
