using Application.DbContext.Models.ACE.Switch;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Persistence.ModelsConfigurations.ACE
{
    public class SwitchAceDbEntityConfiguration : BaseAceDbEntityConfiguration<SwitchAceEntity, SwitchRights>
    {
        public override void Configure(EntityTypeBuilder<SwitchAceEntity> builder)
        {
            base.Configure(builder);

            builder.HasIndex(switchAce => new { switchAce.SwitchId, switchAce.GroupId })
                .IsUnique();

            builder.HasOne(switchAce => switchAce.Switch)
                .WithMany(@switch => @switch.SwitchACL)
                .HasPrincipalKey(@switch => @switch.Id)
                .HasForeignKey(switchAce => switchAce.SwitchId)
                .IsRequired()
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}