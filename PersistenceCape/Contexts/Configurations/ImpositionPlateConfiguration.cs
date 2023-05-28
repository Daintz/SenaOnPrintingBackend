using DataCape.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;

namespace PersistenceCape.Contexts.Configurations
{
    public class ImpositionPlateConfiguration : IEntityTypeConfiguration<ImpositionPlateModel>
    {
        public void Configure(EntityTypeBuilder<ImpositionPlateModel> builder)
        {
            
                builder.HasKey(e => e.IdImpositionPlate);

                builder.ToTable("IMPOSITION_PLATE");

                builder.Property(e => e.IdImpositionPlate).HasColumnName("id_imposition_plate");

                builder.Property(e => e.ImpositionPlateName)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("imposition_plate_name");

                builder.Property(e => e.Scheme).HasColumnName("scheme");

                builder.Property(e => e.StatedAt)
                    .IsRequired()
                    .HasColumnName("stated_at")
                    .HasDefaultValueSql("((1))");
        }
    }
}
