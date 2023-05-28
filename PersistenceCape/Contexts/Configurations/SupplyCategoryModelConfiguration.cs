using DataCape.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System.Reflection.Emit;

namespace PersistenceCape.Contexts.Configurations
{
    public class SupplyCategoryModelConfiguration : IEntityTypeConfiguration<SupplyCategoryModel>
    {
        public void Configure(EntityTypeBuilder<SupplyCategoryModel> builder)
        {
            builder.ToTable("supply_categories");

            builder.Property(e => e.Id).HasColumnName("id");

            builder.Property(e => e.Description)
                .HasMaxLength(150)
                .IsUnicode(false)
                .HasColumnName("description");

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