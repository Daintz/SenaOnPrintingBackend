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
    public class ClientsModelConfiguration : IEntityTypeConfiguration<ClientModel>
    {
        public void Configure(EntityTypeBuilder<ClientModel> builder)
        {
            builder.ToTable("clients");

                builder.HasIndex(e => e.Email, "UQ__clients__AB6E6164160CA661")
                    .IsUnique();

                builder.Property(e => e.Id).HasColumnName("id");

                builder.Property(e => e.Area)
                    .HasMaxLength(250)
                    .IsUnicode(false)
                    .HasColumnName("area");

                builder.Property(e => e.Center)
                    .HasMaxLength(200)
                    .IsUnicode(false)
                    .HasColumnName("center");

                builder.Property(e => e.Email)
                    .HasMaxLength(110)
                    .IsUnicode(false)
                    .HasColumnName("email");

                builder.Property(e => e.Name)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("name");

                builder.Property(e => e.Phone)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("phone");

                builder.Property(e => e.Regional)
                    .HasMaxLength(250)
                    .IsUnicode(false)
                    .HasColumnName("regional");

                builder.Property(e => e.StatedAt)
                    .HasColumnName("stated_at")
                    .HasDefaultValueSql("((1))");
        }
    }
}