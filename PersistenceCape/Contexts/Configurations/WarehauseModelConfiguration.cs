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
            builder.ToTable("warehouse");

            builder.Property(e => e.Id).HasColumnName("id");

            builder.Property(e => e.Name)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("name");

            builder.Property(e => e.StatedAt)
                .HasColumnName("stated_at")
                .HasDefaultValueSql("((1))");

            builder.Property(e => e.Ubication)
                .HasMaxLength(150)
                .IsUnicode(false)
                .HasColumnName("ubication");

            builder.Property(e => e.WarehouseTypeId).HasColumnName("warehouse_type_id");

            builder.HasOne(d => d.WarehouseType)
                .WithMany(p => p.Warehouses)
                .HasForeignKey(d => d.WarehouseTypeId)
                .HasConstraintName("FK__warehouse__wareh__5812160E");
        }
    }
}
