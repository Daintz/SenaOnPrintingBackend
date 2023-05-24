using DataCape.Models;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PersistenceCape.Contexts.Configurations
{
        public class OrderProductionConfiguration : IEntityTypeConfiguration<OrderProductionModel>
        {
            public void Configure(EntityTypeBuilder<OrderProductionModel> builder)
            {
                builder.HasKey(e => e.IdOrderProduction)
                        .HasName("pk_Tbl_0");

                builder.ToTable("ORDER_PRODUCTION");

                builder.Property(e => e.IdOrderProduction).HasColumnName("id_order_production");

                builder.Property(e => e.ColorProfile)
                    .HasMaxLength(255)
                    .HasColumnName("color_profile");

                builder.Property(e => e.IdGrammage).HasColumnName("id_grammage");

                builder.Property(e => e.IdLineature).HasColumnName("id_lineature");

                builder.Property(e => e.IdPaperCutSize).HasColumnName("id_paper_cut_size");

                builder.Property(e => e.IdPlateImposition).HasColumnName("id_plate_imposition");

                builder.Property(e => e.IdProgram).HasColumnName("id_program");

                builder.Property(e => e.IdQuotationClient).HasColumnName("id_quotation_client");

                builder.Property(e => e.IdUser).HasColumnName("id_user");

                builder.Property(e => e.Image).HasColumnName("image");

                builder.Property(e => e.Indented).HasColumnName("indented");

                builder.Property(e => e.InkCode)
                    .HasMaxLength(100)
                    .HasColumnName("ink_code");

                builder.Property(e => e.MaterialReception)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("material_reception");

                builder.Property(e => e.Observations)
                    .HasMaxLength(300)
                    .HasColumnName("observations");

                builder.Property(e => e.OrderStatus).HasColumnName("order_status");

                builder.Property(e => e.ProgramVersion)
                    .HasMaxLength(255)
                    .HasColumnName("program_version");

                builder.Property(e => e.SpecialInk)
                    .HasMaxLength(255)
                    .HasColumnName("special_ink");

                builder.Property(e => e.StatedAt)
                    .IsRequired()
                    .HasColumnName("stated_at")
                    .HasDefaultValueSql("('1')");

                builder.HasOne(d => d.IdGrammageNavigation)
                    .WithMany(p => p.OrderProductions)
                    .HasForeignKey(d => d.IdGrammage)
                    .HasConstraintName("FK_ORDER_PRODUCTION_GRAMMAJE_CALIBER");

                builder.HasOne(d => d.IdLineatureNavigation)
                    .WithMany(p => p.OrderProductions)
                    .HasForeignKey(d => d.IdLineature)
                    .HasConstraintName("FK_ORDER_PRODUCTION_LINEATURE");

                builder.HasOne(d => d.IdPaperCutSizeNavigation)
                    .WithMany(p => p.OrderProductions)
                    .HasForeignKey(d => d.IdPaperCutSize)
                    .HasConstraintName("FK_ORDER_PRODUCTION_PAPER_CUT");

                builder.HasOne(d => d.IdPlateImpositionNavigation)
                    .WithMany(p => p.OrderProductions)
                    .HasForeignKey(d => d.IdPlateImposition)
                    .HasConstraintName("FK_ORDER_PRODUCTION_IMPOSITION_PLATE");

                builder.HasOne(d => d.IdProgramNavigation)
                    .WithMany(p => p.OrderProductions)
                    .HasForeignKey(d => d.IdProgram)
                    .HasConstraintName("FK_ORDER_PRODUCTION_PROGRAM");

                builder.HasOne(d => d.IdQuotationClientNavigation)
                    .WithMany(p => p.OrderProductions)
                    .HasForeignKey(d => d.IdQuotationClient)
                    .HasConstraintName("id_quotation_products");

                builder.HasOne(d => d.IdUserNavigation)
                    .WithMany(p => p.OrderProductions)
                    .HasForeignKey(d => d.IdUser)
                    .HasConstraintName("id_user");
            }
        }
    
}
