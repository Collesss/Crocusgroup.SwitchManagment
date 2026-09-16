using Application.DbContext.Models.ACE.Vlan;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Persistence.ModelsConfigurations.ACE
{
    public class VlanAceDbEntityConfiguration : IEntityTypeConfiguration<VlanAceEntity>
    {
        public void Configure(EntityTypeBuilder<VlanAceEntity> builder)
        {
            builder.HasKey(vlanAce => vlanAce.Id);

            builder.Property(vlanAce => vlanAce.GroupId)
                .HasMaxLength(100)
                .IsRequired();

            builder.HasIndex(vlanAce => new { vlanAce.SwitchId, vlanAce.VlanId, vlanAce.GroupId });

            builder.HasOne(vlanAce => vlanAce.Switch)
                .WithMany(@switch => @switch.VlanACL)
                .HasPrincipalKey(@switch => @switch.Id)
                .HasForeignKey(vlanAce => vlanAce.SwitchId)
                .IsRequired()
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
