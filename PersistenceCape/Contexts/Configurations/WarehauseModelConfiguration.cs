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
    internal class WarehauseModelConfiguration : IEntityTypeConfiguration<WarehouseModel>
    {
        public void Configure(EntityTypeBuilder<WarehouseModel> builder)
        {
            builder.HasKey(e => e.IdWarehouse)
                    .HasName("warehouse_id_warehouse_primary");

            builder.ToTable("WAREHOUSE");

            builder.HasIndex(e => e.IdTypeWarehouse, "unq_WAREHOUSE_id_type_warehouse")
                .IsUnique();

            builder.Property(e => e.IdWarehouse).HasColumnName("id_warehouse");

            builder.Property(e => e.IdTypeWarehouse).HasColumnName("id_type_warehouse");

            builder.Property(e => e.Name)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("name");

            builder.Property(e => e.StatedAt)
                .IsRequired()
                .HasColumnName("stated_at")
                .HasDefaultValueSql("('1')");

            builder.Property(e => e.Ubication)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("ubication");

            builder.HasOne(d => d.IdTypeWarehouseNavigation)
                .WithOne(p => p.Warehouse)
                .HasForeignKey<WarehouseModel>(d => d.IdTypeWarehouse)
                .HasConstraintName("fk_warehouse_warehouse_type");
        }
    }
}
