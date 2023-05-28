using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace DataCape
{
    public partial class SENAONPRINTINGContext : DbContext
    {
        public SENAONPRINTINGContext()
        {
        }

        public SENAONPRINTINGContext(DbContextOptions<SENAONPRINTINGContext> options)
            : base(options)
        {
        }

       
        public virtual DbSet<FinishModel> Finishes { get; set; } = null!;
     
        public virtual DbSet<MachineModel> Machines { get; set; } = null!;
       
        public virtual DbSet<UnitMeasureModel> UnitMeasures { get; set; } = null!;
    

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("Server= DESKTOP-GA5C490;Database= SENAonPrinting;Trusted_Connection=True;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
      


            modelBuilder.Entity<FinishModel>(entity =>
            {
                entity.ToTable("finishes");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Name)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("name");

                entity.Property(e => e.StatedAt)
                    .HasColumnName("stated_at")
                    .HasDefaultValueSql("((1))");
            });

        

            modelBuilder.Entity<MachineModel>(entity =>
            {
                entity.ToTable("machines");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.CostByHour)
                    .HasColumnType("decimal(18, 0)")
                    .HasColumnName("cost_by_hour");

                entity.Property(e => e.CostByUnit)
                    .HasColumnType("decimal(18, 0)")
                    .HasColumnName("cost_by_unit");

                entity.Property(e => e.MaximumHeight)
                    .HasColumnType("decimal(18, 0)")
                    .HasColumnName("maximum_height");

                entity.Property(e => e.MaximumWidth)
                    .HasColumnType("decimal(18, 0)")
                    .HasColumnName("maximum_width");

                entity.Property(e => e.MinimumHeight)
                    .HasColumnType("decimal(18, 0)")
                    .HasColumnName("minimum_height");

                entity.Property(e => e.MinimumWidth)
                    .HasColumnType("decimal(18, 0)")
                    .HasColumnName("minimum_width");

                entity.Property(e => e.Name)
                    .HasMaxLength(150)
                    .IsUnicode(false)
                    .HasColumnName("name");

                entity.Property(e => e.StatedAt)
                    .HasColumnName("stated_at")
                    .HasDefaultValueSql("((1))");
            });

           

            modelBuilder.Entity<UnitMeasureModel>(entity =>
            {
                entity.ToTable("unit_measures");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Abbreviation)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("abbreviation");

                entity.Property(e => e.BaseId).HasColumnName("base_id");

                entity.Property(e => e.ConversionFactor)
                    .HasColumnType("decimal(8, 2)")
                    .HasColumnName("conversion_factor");

                entity.Property(e => e.Name)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("name");

                entity.Property(e => e.StatedAt)
                    .HasColumnName("stated_at")
                    .HasDefaultValueSql("((1))");

                entity.Property(e => e.Type).HasColumnName("type");

                entity.HasOne(d => d.Base)
                    .WithMany(p => p.InverseBase)
                    .HasForeignKey(d => d.BaseId)
                    .HasConstraintName("FK__unit_meas__base___73BA3083");
            });

          

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
