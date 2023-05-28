using DataCape.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace PersistenceCape.Contexts.Configurations
{
    public class SupplyModelConfiguration : IEntityTypeConfiguration<SupplyModel>
    {
        public void Configure(EntityTypeBuilder<SupplyModel> builder)
        {
            builder.ToTable("supplies");

            builder.Property(e => e.Id).HasColumnName("id");

            builder.Property(e => e.Advices)
                .HasColumnType("text")
                .HasColumnName("advices");

            builder.Property(e => e.AverageCost)
                .HasColumnType("decimal(8, 2)")
                .HasColumnName("average_cost");

            builder.Property(e => e.DangerIndicators)
                .HasColumnType("text")
                .HasColumnName("danger_indicators");

            builder.Property(e => e.Name)
                .HasMaxLength(200)
                .IsUnicode(false)
                .HasColumnName("name");

            builder.Property(e => e.Quantity).HasColumnName("quantity");

            builder.Property(e => e.SortingWord).HasColumnName("sorting_word");

            builder.Property(e => e.StatedAt)
                .HasColumnName("stated_at")
                .HasDefaultValueSql("((1))");

            builder.Property(e => e.SupplyType).HasColumnName("supply_type");

            builder.Property(e => e.UseInstructions)
                .HasColumnType("text")
                .HasColumnName("use_instructions");

            builder.Property(e => e.WarehouseId).HasColumnName("warehouse_id");

            builder.HasOne(d => d.Warehouse)
                .WithMany(p => p.Supplies)
                .HasForeignKey(d => d.WarehouseId)
                .HasConstraintName("FK__supplies__wareho__5BE2A6F2");
        }
    }
}
