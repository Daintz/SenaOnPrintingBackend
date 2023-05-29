
using DataCape;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System.Reflection.Emit;

namespace PersistenceCape.Contexts.Configurations
{
    public class MachineModelConfiguration : IEntityTypeConfiguration<MachineModel>
    {
        public void Configure(EntityTypeBuilder<MachineModel> builder)
        {
            

            builder.ToTable("machines");

            builder.Property(e => e.Id).HasColumnName("id");

            builder.Property(e => e.CostByHour)
                .HasColumnType("decimal(18, 0)")
                .HasColumnName("cost_by_hour");

            builder.Property(e => e.CostByUnit)
                .HasColumnType("decimal(18, 0)")
                .HasColumnName("cost_by_unit");

            builder.Property(e => e.MaximumHeight)
                .HasColumnType("decimal(18, 0)")
                .HasColumnName("maximum_height");

            builder.Property(e => e.MaximumWidth)
                .HasColumnType("decimal(18, 0)")
                .HasColumnName("maximum_width");

            builder.Property(e => e.MinimumHeight)
                .HasColumnType("decimal(18, 0)")
                .HasColumnName("minimum_height");

            builder.Property(e => e.MinimumWidth)
                .HasColumnType("decimal(18, 0)")
                .HasColumnName("minimum_width");

            builder.Property(e => e.Name)
                .HasMaxLength(150)
                .IsUnicode(false)
                .HasColumnName("name");

            builder.Property(e => e.StatedAt)
                .HasColumnName("stated_at")
                .HasDefaultValueSql("((1))");
        }
    }
}
