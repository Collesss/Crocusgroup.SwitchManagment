using Application.DbContext.Models.ACE.Vlan;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Persistence.ModelsConfigurations.ACE
{
    public class VlanAceDbEntityConfiguration : BaseAceDbEntityConfiguration<VlanAceEntity, VlanRigths>
    {
        public override void Configure(EntityTypeBuilder<VlanAceEntity> builder)
        {
            base.Configure(builder);

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
