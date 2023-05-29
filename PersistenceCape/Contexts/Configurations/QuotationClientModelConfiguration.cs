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
    public class QuotationClientModelConfiguration : IEntityTypeConfiguration<QuotationClientModel>
    {
        public void Configure(EntityTypeBuilder<QuotationClientModel> builder)
        {
            builder.ToTable("quotation_clients");

            builder.Property(e => e.Id).HasColumnName("id");

            builder.Property(e => e.ClientId).HasColumnName("client_id");

            builder.Property(e => e.DeliverDate)
                .HasColumnType("date")
                .HasColumnName("deliver_date");

            builder.Property(e => e.OrderDate)
                .HasColumnType("date")
                .HasColumnName("order_date");

            builder.Property(e => e.QuotationStatus).HasColumnName("quotation_status");

            builder.Property(e => e.StatedAt)
                .HasColumnName("stated_at")
                .HasDefaultValueSql("((1))");

            builder.Property(e => e.TypeServiceId).HasColumnName("type_service_id");

            builder.Property(e => e.UserId).HasColumnName("user_id");

            builder.HasOne(d => d.Client)
                .WithMany(p => p.QuotationClients)
                .HasForeignKey(d => d.ClientId)
                .HasConstraintName("FK__quotation__clien__208CD6FA");

            builder.HasOne(d => d.TypeService)
                .WithMany(p => p.QuotationClients)
                .HasForeignKey(d => d.TypeServiceId)
                .HasConstraintName("FK__quotation__type___2180FB33");

            builder.HasOne(d => d.User)
                .WithMany(p => p.QuotationClients)
                .HasForeignKey(d => d.UserId)
                .HasConstraintName("FK__quotation__user___1F98B2C1");
        }
    }
}
