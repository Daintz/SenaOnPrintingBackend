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
    internal class WarehauseTypeModelConfiguration : IEntityTypeConfiguration<WarehouseTypeModel>
    {
        public void Configure(EntityTypeBuilder<WarehouseTypeModel> builder)
        {
            builder.HasKey(e => e.IdTypeWarehouse)
                   .HasName("pk_Tbl");

            builder.ToTable("WAREHOUSE_TYPE");

            builder.Property(e => e.IdTypeWarehouse).HasColumnName("id_type_warehouse");

            builder.Property(e => e.Description)
                .IsUnicode(false)
                .HasColumnName("description");

            builder.Property(e => e.Nametype)
                .IsUnicode(false)
                .HasColumnName("nametype");

            builder.Property(e => e.StatedAt)
                .IsRequired()
                .HasColumnName("stated_at")
                .HasDefaultValueSql("('1')");
        }
    }
}
