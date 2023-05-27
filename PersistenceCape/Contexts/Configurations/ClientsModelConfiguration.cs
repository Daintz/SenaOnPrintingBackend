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
            builder.HasKey(e => e.IdClient)
                     .HasName("pk_CLIENTS");

            builder.ToTable("CLIENTS");

            builder.Property(e => e.IdClient).HasColumnName("id_client");

            builder.Property(e => e.Area)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("area");

            builder.Property(e => e.Center)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("center");

            builder.Property(e => e.Email)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("email");

            builder.Property(e => e.Name)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("name");

            builder.Property(e => e.Phone)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("phone");

            builder.Property(e => e.Regional)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("regional");

            builder.Property(e => e.StatedAt)
                .IsRequired()
                .HasColumnName("stated_at")
                .HasDefaultValueSql("('1')");
        }
    }
}
