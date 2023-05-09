using DataCape.Items;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace PersistenceCape.Contexts.Configurations
{
    public class UserItemConfiguration : IEntityTypeConfiguration<UserItem>
    {
        public void Configure(EntityTypeBuilder<UserItem> builder)
        {
            builder.HasNoKey();

            builder.Property(e => e.Id).HasColumnName("ID");

            builder.Property(e => e.Lastname)
                .HasMaxLength(10)
                .IsFixedLength();

            builder.Property(e => e.Name)
                .HasMaxLength(10)
                .IsFixedLength();
        }
    }
}
