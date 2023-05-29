using DataCape.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;


namespace PersistenceCape.Contexts.Configurations
{
    public class ImpositionPlanchConfiguration : IEntityTypeConfiguration<ImpositionPlanchModel>
    {
        public void Configure(EntityTypeBuilder<ImpositionPlanchModel> builder)
        {
            builder.ToTable("imposition_planch");

            builder.Property(e => e.Id).HasColumnName("id");

            builder.Property(e => e.Name)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("name");

            builder.Property(e => e.Scheme).HasColumnName("scheme");

            builder.Property(e => e.StatedAt)
                .HasColumnName("stated_at")
                .HasDefaultValueSql("((1))");
        }
    }
}
