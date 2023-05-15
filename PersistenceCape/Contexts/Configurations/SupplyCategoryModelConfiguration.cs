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
            builder.HasKey(e => e.IdSupplyCategory)
                    .HasName("supply_categories_id_supply_category_primary");

            builder.ToTable("SUPPLY_CATEGORIES");

            builder.Property(e => e.IdSupplyCategory).HasColumnName("id_supply_category");

            builder.Property(e => e.Description)
                .HasMaxLength(255)
                .HasColumnName("description");

            builder.Property(e => e.Name)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("name");

            builder.Property(e => e.StatedAt)
                .IsRequired()
                .HasColumnName("stated_at");
        }
    }
}
