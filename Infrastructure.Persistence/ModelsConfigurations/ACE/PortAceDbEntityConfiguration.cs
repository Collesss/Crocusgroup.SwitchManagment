using Application.DbContext.Models.ACE.Port;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Persistence.ModelsConfigurations.ACE
{
    public class PortAceDbEntityConfiguration : BaseAceDbEntityConfiguration<PortAceEntity, PortRights>
    {
        public override void Configure(EntityTypeBuilder<PortAceEntity> builder)
        {
            base.Configure(builder);

            builder.Property(portAce => portAce.InterfaceName)
                .IsRequired()
                .HasMaxLength(100);

            builder.HasIndex(portAce => new { portAce.SwitchId, portAce.GroupId, portAce.InterfaceName })
                .IsUnique();

            builder.HasOne(portAce => portAce.Switch)
                .WithMany(@switch => @switch.PortACL)
                .HasPrincipalKey(@switch => @switch.Id)
                .HasForeignKey(portAce => portAce.SwitchId)
                .IsRequired()
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
