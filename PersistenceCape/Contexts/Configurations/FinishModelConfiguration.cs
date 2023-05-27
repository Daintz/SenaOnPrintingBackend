
using DataCape;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System.Reflection.Emit;

namespace PersistenceCape.Contexts.Configurations
{
    public class FinishModelConfiguration : IEntityTypeConfiguration<Finish>
    {
        public void Configure(EntityTypeBuilder<Finish> builder)
        {
            builder.ToTable("finishes");

            builder.Property(e => e.Id).HasColumnName("id");

            builder.Property(e => e.Name)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("name");

            builder.Property(e => e.StatedAt)
                .HasColumnName("stated_at")
                .HasDefaultValueSql("((1))");
        }
    }
}
