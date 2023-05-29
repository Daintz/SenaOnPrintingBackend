using System;
using System.Collections.Generic;
using DataCape.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace PersistenceCape.Contexts
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

        public virtual DbSet<ApplicationPermissionModel> ApplicationPermissions { get; set; } = null!;
     
        public virtual DbSet<PermissionsByRoleModel> PermissionsByRoles { get; set; } = null!;
 
        public virtual DbSet<ProviderModel> Providers { get; set; } = null!;
     
        public virtual DbSet<RoleModel> Roles { get; set; } = null!;
     
        public virtual DbSet<TypeDocumentModel> TypeDocuments { get; set; } = null!;
      
        public virtual DbSet<UserModel> Users { get; set; } = null!;
        public virtual DbSet<WarehouseModel> Warehouses { get; set; } = null!;
        public virtual DbSet<WarehouseTypeModel> WarehouseTypes { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=sena_on_printing;Integrated Security=True;Connect Timeout=30;Encrypt=False;Trust Server Certificate=False;Application Intent=ReadWrite;Multi Subnet Failover=False");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<ApplicationPermissionModel>(entity =>
            {
                entity.ToTable("application_permissions");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Name)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("name");
            });

            modelBuilder.Entity<PermissionsByRoleModel>(entity =>
            {
                entity.ToTable("permissions_by_role");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.PermissionId).HasColumnName("permission_id");

                entity.Property(e => e.RoleId).HasColumnName("role_id");

                entity.Property(e => e.StatedAt)
                    .HasColumnName("stated_at")
                    .HasDefaultValueSql("((1))");

                entity.HasOne(d => d.Permission)
                    .WithMany(p => p.PermissionsByRoles)
                    .HasForeignKey(d => d.PermissionId)
                    .HasConstraintName("FK__permissio__permi__3B75D760");
                entity.HasOne(d => d.Role)
                    .WithMany(p => p.PermissionsByRoles)
                    .HasForeignKey(d => d.RoleId)
                    .HasConstraintName("FK__permissio__role___3C69FB99");
            });

            modelBuilder.Entity<ProviderModel>(entity =>
            {
                entity.ToTable("providers");

                entity.HasIndex(e => e.Email, "UQ__provider__AB6E6164B50CE394")
                    .IsUnique();

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.CompanyAddress)
                    .HasMaxLength(150)
                    .IsUnicode(false)
                    .HasColumnName("company_address");

                entity.Property(e => e.Email)
                    .HasMaxLength(110)
                    .IsUnicode(false)
                    .HasColumnName("email");

                entity.Property(e => e.NameCompany)
                    .HasMaxLength(250)
                    .IsUnicode(false)
                    .HasColumnName("name_company");

                entity.Property(e => e.NitCompany)
                    .HasMaxLength(15)
                    .IsUnicode(false)
                    .HasColumnName("nit_company");

                entity.Property(e => e.Phone)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("phone");

                entity.Property(e => e.StatedAt)
                    .HasColumnName("stated_at")
                    .HasDefaultValueSql("((1))");
            });

            modelBuilder.Entity<RoleModel>(entity =>
            {
                entity.ToTable("roles");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Description)
                    .HasMaxLength(150)
                    .IsUnicode(false)
                    .HasColumnName("description");

                entity.Property(e => e.Name)
                    .HasMaxLength(80)
                    .IsUnicode(false)
                    .HasColumnName("name");

                entity.Property(e => e.StatedAt)
                    .HasColumnName("stated_at")
                    .HasDefaultValueSql("((1))");
            });

            modelBuilder.Entity<TypeDocumentModel>(entity =>
            {
                entity.ToTable("type_documents");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Abbreviation)
                    .HasMaxLength(5)
                    .IsUnicode(false)
                    .HasColumnName("abbreviation");

                entity.Property(e => e.Name)
                    .HasMaxLength(80)
                    .IsUnicode(false)
                    .HasColumnName("name");

                entity.Property(e => e.StatedAt)
                    .HasColumnName("stated_at")
                    .HasDefaultValueSql("((1))");
            });

            modelBuilder.Entity<UserModel>(entity =>
            {
                entity.ToTable("users");

                entity.HasIndex(e => e.Email, "UQ__users__AB6E61649D4066DB")
                    .IsUnique();

                entity.HasIndex(e => e.DocumentNumber, "UQ__users__C8FE0D8CB1737385")
                    .IsUnique();

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Address)
                    .HasMaxLength(150)
                    .IsUnicode(false)
                    .HasColumnName("address");

                entity.Property(e => e.DocumentNumber)
                    .HasMaxLength(15)
                    .IsUnicode(false)
                    .HasColumnName("document_number");

                entity.Property(e => e.Email)
                    .HasMaxLength(110)
                    .IsUnicode(false)
                    .HasColumnName("email");

                entity.Property(e => e.Names)
                    .HasMaxLength(90)
                    .IsUnicode(false)
                    .HasColumnName("names");

                entity.Property(e => e.PasswordDigest)
                    .HasMaxLength(250)
                    .IsUnicode(false)
                    .HasColumnName("password_digest");

                entity.Property(e => e.Phone)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("phone");

                entity.Property(e => e.RoleId).HasColumnName("role_id");

                entity.Property(e => e.StatedAt)
                    .HasColumnName("stated_at")
                    .HasDefaultValueSql("((1))");

                entity.Property(e => e.Surnames)
                    .HasMaxLength(90)
                    .IsUnicode(false)
                    .HasColumnName("surnames");

                entity.Property(e => e.TypeDocumentId).HasColumnName("type_document_id");

                entity.HasOne(d => d.Role)
                    .WithMany(p => p.Users)
                    .HasForeignKey(d => d.RoleId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__users__role_id__45F365D3");

                entity.HasOne(d => d.TypeDocument)
                    .WithMany(p => p.Users)
                    .HasForeignKey(d => d.TypeDocumentId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__users__type_docu__44FF419A");
            });

            modelBuilder.Entity<WarehouseModel>(entity =>
            {
                entity.ToTable("warehouse");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Name)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("name");

                entity.Property(e => e.StatedAt)
                    .HasColumnName("stated_at")
                    .HasDefaultValueSql("((1))");

                entity.Property(e => e.Ubication)
                    .HasMaxLength(150)
                    .IsUnicode(false)
                    .HasColumnName("ubication");

                entity.Property(e => e.WarehouseTypeId).HasColumnName("warehouse_type_id");

                entity.HasOne(d => d.WarehouseType)
                    .WithMany(p => p.Warehouses)
                    .HasForeignKey(d => d.WarehouseTypeId)
                    .HasConstraintName("FK__warehouse__wareh__571DF1D5");
            });

            modelBuilder.Entity<WarehouseTypeModel>(entity =>
            {
                entity.ToTable("warehouse_type");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Description)
                    .HasMaxLength(150)
                    .IsUnicode(false)
                    .HasColumnName("description");

                entity.Property(e => e.Name)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("name");

                entity.Property(e => e.StatedAt)
                    .HasColumnName("stated_at")
                    .HasDefaultValueSql("((1))");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
