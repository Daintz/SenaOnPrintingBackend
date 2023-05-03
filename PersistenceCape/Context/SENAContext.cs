using System;
using System.Collections.Generic;
using DataCape;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace PersistenceCape.Context
{
    public partial class SENAContext : DbContext
    {
        public SENAContext()
        {
        }

        public SENAContext(DbContextOptions<SENAContext> options)
            : base(options)
        {
        }

        public virtual DbSet<UserItem> Users { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<UserItem>(entity =>
            {
                entity.HasNoKey();

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.Lastname)
                    .HasMaxLength(10)
                    .IsFixedLength();

                entity.Property(e => e.Name)
                    .HasMaxLength(10)
                    .IsFixedLength();
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
