using Application.DbContext.Models.ACE;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Persistence.ModelsConfigurations.ACE
{
    public class BaseAceDbEntityConfiguration<T, TRights> : IEntityTypeConfiguration<T>
        where T : BaseAceEntity<TRights>
        where TRights : Enum
    {
        public virtual void Configure(EntityTypeBuilder<T> builder)
        {
            builder.HasKey(ace => ace.Id);

            builder.Property(ace => ace.GroupId)
                .HasMaxLength(100)
                .IsRequired();
        }
    }
}
