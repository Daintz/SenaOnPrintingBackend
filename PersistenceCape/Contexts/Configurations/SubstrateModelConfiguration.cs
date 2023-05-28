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
    public class SubstrateModelConfiguration : IEntityTypeConfiguration<SubstrateModel>
    {
        public void Configure(EntityTypeBuilder<SubstrateModel> builder)
        {
            builder.ToTable("substrates");

            builder.Property(e => e.Id).HasColumnName("id");

            builder.Property(e => e.Name)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("name");

            builder.Property(e => e.StatedAt)
                .HasColumnName("stated_at")
                .HasDefaultValueSql("((1))");
        }
    }
}
