using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Application.DbContext.Models;

namespace Infrastructure.Persistence.ModelsConfigurations
{
    public class SwitchDbEntityConfiguration : IEntityTypeConfiguration<SwitchEntity>
    {
        public void Configure(EntityTypeBuilder<SwitchEntity> builder)
        {
            builder.HasKey(@switch => @switch.Id);

            builder.Property(@switch => @switch.IpOrName)
                .HasMaxLength(100)
                .IsRequired();

            builder.HasIndex(@switch => @switch.IpOrName)
                .IsUnique();

            builder.Property(@switch => @switch.Location)
                .HasMaxLength(100);

            builder.Property(@switch => @switch.Description)
                .HasMaxLength(100);

            builder.Property(@switch => @switch.Handler)
                .HasMaxLength(100);

            builder.Property(@switch => @switch.Login)
                .HasMaxLength(100);

            builder.Property(@switch => @switch.Password)
                .HasMaxLength(100);

            builder.Property(@switch => @switch.SuperPassword)
                .HasMaxLength(100);

            /*
            builder.HasMany(@switch => @switch.SwitchACL)
                .WithOne(switchACE => switchACE.Switch)
                .HasPrincipalKey(@switch => @switch.Id)
                .HasForeignKey(switchACE => switchACE.SwitchId)
                .IsRequired()
                .OnDelete(DeleteBehavior.Cascade);

            builder.HasMany(@switch => @switch.PortACL)
                .WithOne(portACE => portACE.Switch)
                .HasPrincipalKey(@switch => @switch.Id)
                .HasForeignKey(portACE => portACE.SwitchId)
                .IsRequired()
                .OnDelete(DeleteBehavior.Cascade);

            builder.HasMany(@switch => @switch.VlanACL)
                .WithOne(vlanACE => vlanACE.Switch)
                .HasPrincipalKey(@switch => @switch.Id)
                .HasForeignKey(vlanACE => vlanACE.SwitchId)
                .IsRequired()
                .OnDelete(DeleteBehavior.Cascade);

            builder.HasMany(@switch => @switch.VlanOnPortACL)
                .WithOne(vlanOnPortACE => vlanOnPortACE.Switch)
                .HasPrincipalKey(@switch => @switch.Id)
                .HasForeignKey(vlanOnPortACE => vlanOnPortACE.SwitchId)
                .IsRequired()
                .OnDelete(DeleteBehavior.Cascade);
            */
        }
    }
}
