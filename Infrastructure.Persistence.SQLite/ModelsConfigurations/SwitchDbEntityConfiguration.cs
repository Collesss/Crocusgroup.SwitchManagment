using Infrastructure.Persistence.SQLite.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Persistence.SQLite.ModelsConfigurations
{
    public class SwitchDbEntityConfiguration : IEntityTypeConfiguration<SwitchDbEntity>
    {
        public void Configure(EntityTypeBuilder<SwitchDbEntity> builder)
        {
            builder.HasKey(@switch => @switch.Id);

            builder.Property(@switch => @switch.IpOrName)
                .HasMaxLength(100)
                .IsRequired();

            builder.HasIndex(@switch => @switch.IpOrName)
                .IsUnique();

        }
    }
}
