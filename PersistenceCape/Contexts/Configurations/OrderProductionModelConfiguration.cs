using DataCape.Models;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;


namespace PersistenceCape.Contexts.Configurations
{
        public class OrderProductionConfiguration : IEntityTypeConfiguration<OrderProductionModel>
        {
            public void Configure(EntityTypeBuilder<OrderProductionModel> builder)
        {
                builder.ToTable("order_production");

                builder.Property(e => e.Id).HasColumnName("id");

                builder.Property(e => e.ColorProfile)
                    .HasMaxLength(255)
                    .HasColumnName("color_profile");

                builder.Property(e => e.IdPaperCut).HasColumnName("id_paper_cut");

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

                builder.Property(e => e.Program)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("program");

                builder.Property(e => e.ProgramVersion)
                    .HasMaxLength(255)
                    .HasColumnName("program_version");

                builder.Property(e => e.QuotationClientDetailId).HasColumnName("quotation_client_detail_id");

                builder.Property(e => e.SpecialInk)
                    .HasMaxLength(255)
                    .HasColumnName("special_ink");

                builder.Property(e => e.StatedAt).HasColumnName("stated_at");

                builder.Property(e => e.UserId).HasColumnName("user_id");

                builder.HasOne(d => d.IdPaperCutNavigation)
                    .WithMany(p => p.OrderProductions)
                    .HasForeignKey(d => d.IdPaperCut)
                    .HasConstraintName("FK__order_pro__id_pa__1CBC4616");

                builder.HasOne(d => d.QuotationClientDetail)
                    .WithMany(p => p.OrderProductions)
                    .HasForeignKey(d => d.QuotationClientDetailId)
                    .HasConstraintName("FK__order_pro__quota__1AD3FDA4");

                builder.HasOne(d => d.User)
                    .WithMany(p => p.OrderProductions)
                    .HasForeignKey(d => d.UserId)
                    .HasConstraintName("FK__order_pro__user___1BC821DD");

            }
        }
    
}
