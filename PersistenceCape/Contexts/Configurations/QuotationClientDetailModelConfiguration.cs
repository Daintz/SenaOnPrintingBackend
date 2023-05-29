using DataCape.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PersistenceCape.Contexts.Configurations
{
    public class QuotationClientDetailModelConfiguration : IEntityTypeConfiguration<QuotationClientDetailModel>
    {
        public void Configure(EntityTypeBuilder<QuotationClientDetailModel> builder)
        {
            builder.ToTable("quotation_client_details");

            builder.Property(e => e.Id).HasColumnName("id");

            builder.Property(e => e.FullValue).HasColumnName("full_value");

            builder.Property(e => e.InkQuantity).HasColumnName("ink_quantity");

            builder.Property(e => e.NumberOfPages).HasColumnName("number_of_pages");

            builder.Property(e => e.ProductHeight).HasColumnName("product_height");

            builder.Property(e => e.ProductId).HasColumnName("product_id");

            builder.Property(e => e.ProductQuantity).HasColumnName("product_quantity");
                
            builder.Property(e => e.ProductWidth).HasColumnName("product_width");

            builder.Property(e => e.QuotationClientId).HasColumnName("quotation_client_id");

            builder.Property(e => e.StatedAt)
                .HasColumnName("stated_at")
                .HasDefaultValueSql("((1))");

            builder.Property(e => e.TechnicalSpecifications)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("technical_specifications");

            builder.Property(e => e.UnitValue).HasColumnName("unit_value");

            builder.HasOne(d => d.Product)
                .WithMany(p => p.QuotationClientDetails)
                .HasForeignKey(d => d.ProductId)
                .HasConstraintName("FK__quotation__produ__2645B050");

            builder.HasOne(d => d.QuotationClient)
                .WithMany(p => p.QuotationClientDetails)
                .HasForeignKey(d => d.QuotationClientId)
                .HasConstraintName("FK__quotation__quota__25518C17");
        }
    }
}
