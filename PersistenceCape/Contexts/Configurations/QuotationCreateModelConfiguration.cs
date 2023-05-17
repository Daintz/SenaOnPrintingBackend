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
    public class QuotationCreateModelConfiguration : IEntityTypeConfiguration<QuotationClientModel>
    {
        public void Configure(EntityTypeBuilder<QuotationClientModel> builder)
        {

            {
                builder.HasKey(e => e.IdQuotationClient)
                    .HasName("pk_QUOTATION_PRODUCTS");

                builder.ToTable("QUOTATION_CLIENTS");

                builder.Property(e => e.IdQuotationClient).HasColumnName("id_quotation_client");

                builder.Property(e => e.DateOrde)
                    .HasColumnType("date")
                    .HasColumnName("date_orde");

                builder.Property(e => e.DeliverDate)
                    .HasColumnType("date")
                    .HasColumnName("deliver_date");

                builder.Property(e => e.FullValue).HasColumnName("full_value");

                builder.Property(e => e.IdClient).HasColumnName("id_client");

                builder.Property(e => e.IdFinishes).HasColumnName("id_finishes");

                builder.Property(e => e.IdMachine).HasColumnName("id_machine");

                builder.Property(e => e.IdProduct).HasColumnName("id_product");

                builder.Property(e => e.IdSubstrate).HasColumnName("id_substrate");

                builder.Property(e => e.IdTypeService).HasColumnName("id_type_service");

                builder.Property(e => e.IdUser).HasColumnName("id_user");

                builder.Property(e => e.InkQuantity).HasColumnName("ink_quantity");

                builder.Property(e => e.NumberOfPages).HasColumnName("number_of_pages");

                builder.Property(e => e.ProductHigh).HasColumnName("product_high");

                builder.Property(e => e.ProductQuantity).HasColumnName("product_quantity");

                builder.Property(e => e.ProductWidth).HasColumnName("product_width");

                builder.Property(e => e.QuotationStatus).HasColumnName("quotation_status");

                builder.Property(e => e.StatedAt)
                    .IsRequired()
                    .HasColumnName("stated_at")
                    .HasDefaultValueSql("('1')");

                builder.Property(e => e.TechnicalSpecifications)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("technical_specifications");

                builder.Property(e => e.UnitValue).HasColumnName("unit_value");

            }
        }
    }
}
