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
    public class ProviderModelConfiguration : IEntityTypeConfiguration<ProviderModel>
    {
        public void Configure(EntityTypeBuilder<ProviderModel> builder)
        {
            builder.HasKey(e => e.IdProvider)
                   .HasName("pk_PROVIDERS");

            builder.ToTable("PROVIDERS");

            builder.Property(e => e.IdProvider).HasColumnName("id_provider");

            builder.Property(e => e.CompanyAddress)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("company_address");

            builder.Property(e => e.Email)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("email");

            builder.Property(e => e.NameCompany)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("name_company");

            builder.Property(e => e.NitCompany).HasColumnName("nit_company");

            builder.Property(e => e.Phone)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("phone");

            builder.Property(e => e.StatedAt)
                .IsRequired()
                .HasColumnName("stated_at")
                .HasDefaultValueSql("('1')");
        }
    }
}
