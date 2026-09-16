using Application.DbContext.Models.ACE.Switch;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Persistence.ModelsConfigurations.ACE
{
    public class SwitchAceDbEntityConfiguration : IEntityTypeConfiguration<SwitchAceEntity>
    {
        public void Configure(EntityTypeBuilder<SwitchAceEntity> builder)
        {
            builder.HasKey(switchAce => switchAce.Id);

            builder.Property(switchAce => switchAce.GroupId)
                .HasMaxLength(100)
                .IsRequired();

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