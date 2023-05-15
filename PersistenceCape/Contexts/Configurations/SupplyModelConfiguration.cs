using DataCape.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace PersistenceCape.Contexts.Configurations
{
    public class SupplyModelConfiguration : IEntityTypeConfiguration<SupplyModel>
    {
        public void Configure(EntityTypeBuilder<SupplyModel> builder)
        {
            builder.HasKey(e => e.IdSupply)
                    .HasName("supplies_id_supply_primary");

            builder.ToTable("SUPPLIES");

            builder.HasIndex(e => e.IdWarehouse, "supplies_id_warehouse_unique")
                .IsUnique();

            builder.HasIndex(e => e.MinimunUnitMeasureId, "supplies_minimun_unit_measure_id_unique")
                .IsUnique();

            builder.Property(e => e.IdSupply).HasColumnName("id_supply");

            builder.Property(e => e.Advices)
                .HasMaxLength(255)
                .HasColumnName("advices");

            builder.Property(e => e.AverageCost)
                .HasColumnType("decimal(8, 2)")
                .HasColumnName("average_cost");

            builder.Property(e => e.DangerIndicators)
                .HasMaxLength(255)
                .HasColumnName("danger_indicators");

            builder.Property(e => e.IdWarehouse).HasColumnName("id_warehouse");

            builder.Property(e => e.MinimunUnitMeasureId).HasColumnName("minimun_unit_measure_id");

            builder.Property(e => e.Name)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("name");

            builder.Property(e => e.Quantity).HasColumnName("quantity");

            builder.Property(e => e.SortingWord).HasColumnName("sorting_word");

            builder.Property(e => e.StatedAt)
                .IsRequired()
                .HasColumnName("stated_at")
                .HasDefaultValueSql("('1')");

            builder.Property(e => e.SupplyType).HasColumnName("supply_type");

            builder.Property(e => e.UseInstructions)
                .HasMaxLength(255)
                .HasColumnName("use_instructions");

            builder.HasOne(d => d.IdWarehouseNavigation)
                .WithOne(p => p.Supply)
                .HasForeignKey<SupplyModel>(d => d.IdWarehouse)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("supplies_id_warehouse_foreign");
        }
    }
}
