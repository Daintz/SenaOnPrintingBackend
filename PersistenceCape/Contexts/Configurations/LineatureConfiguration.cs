using DataCape.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;


namespace PersistenceCape.Contexts.Configurations
{
    public class LineatureConfiguration : IEntityTypeConfiguration<LineatureModel>
    {
        public void Configure(EntityTypeBuilder<LineatureModel> builder)
        {

            builder.ToTable("lineature");

            builder.Property(e => e.Id).HasColumnName("id");

            builder.Property(e => e.Lineature)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("lineature");

            builder.Property(e => e.StatedAt)
                .HasColumnName("stated_at")
                .HasDefaultValueSql("((1))");

            builder.Property(e => e.TypePoint)
                .HasMaxLength(150)
                .IsUnicode(false)
                .HasColumnName("type_point");
        }
    }
}
