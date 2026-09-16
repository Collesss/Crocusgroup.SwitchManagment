using Application.DbContext.Models.ACE.Port;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Persistence.ModelsConfigurations.ACE
{
    public class PortAceDbEntityConfiguration : IEntityTypeConfiguration<PortAceEntity>
    {
        public void Configure(EntityTypeBuilder<PortAceEntity> builder)
        {
            builder.HasKey(portAce => portAce.Id);

            builder.Property(portAce => portAce.GroupId)
                .HasMaxLength(100)
                .IsRequired();

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
