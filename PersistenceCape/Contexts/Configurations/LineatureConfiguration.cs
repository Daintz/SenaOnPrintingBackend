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
    public class LineatureConfiguration : IEntityTypeConfiguration<LineatureModel>
    {
        public void Configure(EntityTypeBuilder<LineatureModel> builder)
        {
                builder.HasKey(e => e.IdLineature);

                builder.ToTable("LINEATURE");

                builder.Property(e => e.IdLineature).HasColumnName("id_lineature");

                builder.Property(e => e.Lineature1)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("lineature");

                builder.Property(e => e.Other)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("other");

                builder.Property(e => e.StatedAt)
                    .IsRequired()
                    .HasColumnName("stated_at")
                    .HasDefaultValueSql("((1))");

                builder.Property(e => e.TypePoint)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("type_point");
        }
    }
}
