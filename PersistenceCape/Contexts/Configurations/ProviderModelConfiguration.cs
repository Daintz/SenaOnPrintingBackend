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
            builder.ToTable("providers");

            builder.HasIndex(e => e.Email, "UQ__provider__AB6E616458EEF016")
                .IsUnique();

            builder.Property(e => e.Id).HasColumnName("id");

            builder.Property(e => e.CompanyAddress)
                .HasMaxLength(150)
                .IsUnicode(false)
                .HasColumnName("company_address");

            builder.Property(e => e.Email)
                .HasMaxLength(110)
                .IsUnicode(false)
                .HasColumnName("email");

            builder.Property(e => e.NameCompany)
                .HasMaxLength(250)
                .IsUnicode(false)
                .HasColumnName("name_company");

            builder.Property(e => e.NitCompany)
                .HasMaxLength(15)
                .IsUnicode(false)
                .HasColumnName("nit_company");

            builder.Property(e => e.Phone)
                .HasMaxLength(10)
                .IsUnicode(false)
                .HasColumnName("phone");

            builder.Property(e => e.StatedAt)
                .HasColumnName("stated_at")
                .HasDefaultValueSql("((1))");
        }
    }
}
