using Application.DbContext.Models.ACE.VlanOnPort;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Persistence.ModelsConfigurations.ACE
{
    public class VlanOnPortAceDbEntityConfiguration : IEntityTypeConfiguration<VlanOnPortAceEntity>
    {
        public void Configure(EntityTypeBuilder<VlanOnPortAceEntity> builder)
        {
            builder.HasKey(valnOnPortAce => valnOnPortAce.Id);

            builder.Property(valnOnPortAce => valnOnPortAce.GroupId)
                .HasMaxLength(100)
                .IsRequired();

            builder.HasIndex(valnOnPortAce => new { valnOnPortAce.SwitchId, valnOnPortAce.VlanId, valnOnPortAce.InterfaceName, valnOnPortAce.GroupId });

            builder.HasOne(valnOnPortAce => valnOnPortAce.Switch)
                .WithMany(@switch => @switch.VlanOnPortACL)
                .HasPrincipalKey(@switch => @switch.Id)
                .HasForeignKey(valnOnPortAce => valnOnPortAce.SwitchId)
                .IsRequired()
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
