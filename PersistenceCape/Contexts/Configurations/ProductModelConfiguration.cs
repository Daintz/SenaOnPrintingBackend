using DataCape.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace PersistenceCape.Contexts.Configurations
{
    public class ProductModelConfiguration : IEntityTypeConfiguration<ProductModel>
    {
        public void Configure(EntityTypeBuilder<ProductModel> builder)
        {
            builder.ToTable("products");

            builder.Property(e => e.Id).HasColumnName("id");

            builder.Property(e => e.Characteristics)
                .HasColumnType("text")
                .HasColumnName("characteristics");

            builder.Property(e => e.Name)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("name");

            builder.Property(e => e.StatedAt)
                .HasColumnName("stated_at")
                .HasDefaultValueSql("((1))");

            builder.Property(e => e.TypeProduct)
                .HasMaxLength(150)
                .IsUnicode(false)
                .HasColumnName("type_product")
                .HasDefaultValueSql("((1))");
        }
    }
}
