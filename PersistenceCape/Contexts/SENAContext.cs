using System.Reflection;
using DataCape.Models;
using Microsoft.EntityFrameworkCore;

namespace PersistenceCape.Contexts
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

        public virtual DbSet<PermissionModel> Permissions { get; set; } = null!;
        public virtual DbSet<PermissionsXRoleModel> PermissionsXRoles { get; set; } = null!;
        public virtual DbSet<RoleModel> Roles { get; set; } = null!;
        public virtual DbSet<SupplyModel> Supplies { get; set; } = null!;
        public virtual DbSet<SupplyCategoriesXSupplyModel> SupplyCategoriesXSupplies { get; set; } = null!;
        public virtual DbSet<SupplyCategoryModel> SupplyCategories { get; set; } = null!;
        public virtual DbSet<SupplyPictogramModel> SupplyPictograms { get; set; } = null!;
        public virtual DbSet<SupplyXSupplyPictogramModel> SupplyXSupplyPictograms { get; set; } = null!;
        public virtual DbSet<TypeDocumentModel> TypeDocuments { get; set; } = null!;
        public virtual DbSet<UnitMeasureModel> UnitMeasures { get; set; } = null!;
        public virtual DbSet<UnitMeasuresXSupplyModel> UnitMeasuresXSupplies { get; set; } = null!;
        public virtual DbSet<UserModel> Users { get; set; } = null!;
        public virtual DbSet<WarehouseModel> Warehouses { get; set; } = null!;

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:Collation", "Modern_Spanish_CI_AS");

            modelBuilder.Entity<PermissionModel>(entity =>
            {
                entity.HasKey(e => e.IdPermission)
                    .HasName("permissions_id_permission_primary");

                entity.ToTable("PERMISSIONS");

                entity.Property(e => e.IdPermission)
                    .ValueGeneratedNever()
                    .HasColumnName("id_permission");

                entity.Property(e => e.Permission1)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("permission");

                entity.Property(e => e.StatedAt).HasColumnName("stated_at");
            });

            modelBuilder.Entity<PermissionsXRoleModel>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("PERMISSIONS_X_ROLES");

                entity.HasIndex(e => e.IdPermission, "permissions_x_roles_id_permission_unique")
                    .IsUnique();

                entity.HasIndex(e => e.IdRole, "permissions_x_roles_id_role_unique")
                    .IsUnique();

                entity.Property(e => e.IdPermission).HasColumnName("id_permission");

                entity.Property(e => e.IdRole).HasColumnName("id_role");

                entity.HasOne(d => d.IdPermissionNavigation)
                    .WithOne()
                    .HasForeignKey<PermissionsXRoleModel>(d => d.IdPermission)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("permissions_x_roles_id_permission_foreign");

                entity.HasOne(d => d.IdRoleNavigation)
                    .WithOne()
                    .HasForeignKey<PermissionsXRoleModel>(d => d.IdRole)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("permissions_x_roles_id_role_foreign");
            });

            modelBuilder.Entity<RoleModel>(entity =>
            {
                entity.HasKey(e => e.IdRole)
                    .HasName("roles_id_role_primary");

                entity.ToTable("ROLES");

                entity.Property(e => e.IdRole)
                    .ValueGeneratedNever()
                    .HasColumnName("id_role");

                entity.Property(e => e.Description)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("description");

                entity.Property(e => e.Name)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("name");

                entity.Property(e => e.StatedAt)
                    .IsRequired()
                    .HasColumnName("stated_at")
                    .HasDefaultValueSql("('1')");
            });

            modelBuilder.Entity<SupplyCategoriesXSupplyModel>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("SUPPLY_CATEGORIES_X_SUPPLY");

                entity.HasIndex(e => e.IdSupplyCategory, "supply_categories_x_supply_id_supply_category_unique")
                    .IsUnique();

                entity.HasIndex(e => e.IdSupply, "supply_categories_x_supply_id_supply_unique")
                    .IsUnique();

                entity.Property(e => e.IdSupply).HasColumnName("id_supply");

                entity.Property(e => e.IdSupplyCategory).HasColumnName("id_supply_category");

                entity.HasOne(d => d.IdSupplyNavigation)
                    .WithOne()
                    .HasForeignKey<SupplyCategoriesXSupplyModel>(d => d.IdSupply)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("supply_categories_x_supply_id_supply_foreign");

                entity.HasOne(d => d.IdSupplyCategoryNavigation)
                    .WithOne()
                    .HasForeignKey<SupplyCategoriesXSupplyModel>(d => d.IdSupplyCategory)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("supply_categories_x_supply_id_supply_category_foreign");
            });

            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());

            modelBuilder.Entity<SupplyPictogramModel>(entity =>
            {
                entity.HasKey(e => e.IdPictogram)
                    .HasName("supply_pictograms_id_pictogram_primary");

                entity.ToTable("SUPPLY_PICTOGRAMS");

                entity.Property(e => e.IdPictogram)
                    .ValueGeneratedNever()
                    .HasColumnName("id_pictogram");

                entity.Property(e => e.Name)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("name");

                entity.Property(e => e.Pictogram).HasColumnName("pictogram");

                entity.Property(e => e.StatedAt)
                    .IsRequired()
                    .HasColumnName("stated_at")
                    .HasDefaultValueSql("('1')");
            });

            modelBuilder.Entity<SupplyXSupplyPictogramModel>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("SUPPLY_X_SUPPLY_PICTOGRAMS");

                entity.HasIndex(e => e.IdSupplyPictogram, "supply_x_supply_pictograms_id_supply_pictogram_unique")
                    .IsUnique();

                entity.HasIndex(e => e.IdSupply, "supply_x_supply_pictograms_id_supply_unique")
                    .IsUnique();

                entity.Property(e => e.IdSupply).HasColumnName("id_supply");

                entity.Property(e => e.IdSupplyPictogram).HasColumnName("id_supply_pictogram");

                entity.HasOne(d => d.IdSupplyNavigation)
                    .WithOne()
                    .HasForeignKey<SupplyXSupplyPictogramModel>(d => d.IdSupply)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("supply_x_supply_pictograms_id_supply_foreign");

                entity.HasOne(d => d.IdSupplyPictogramNavigation)
                    .WithOne()
                    .HasForeignKey<SupplyXSupplyPictogramModel>(d => d.IdSupplyPictogram)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("supply_x_supply_pictograms_id_supply_pictogram_foreign");
            });

            modelBuilder.Entity<TypeDocumentModel>(entity =>
            {
                entity.HasKey(e => e.IdTypeDocument)
                    .HasName("type_documents_id_type_document_primary");

                entity.ToTable("TYPE_DOCUMENTS");

                entity.Property(e => e.IdTypeDocument)
                    .ValueGeneratedNever()
                    .HasColumnName("id_type_document");

                entity.Property(e => e.Abbreviation)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("abbreviation");

                entity.Property(e => e.Name)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("name");

                entity.Property(e => e.StatedAt)
                    .IsRequired()
                    .HasColumnName("stated_at")
                    .HasDefaultValueSql("('1')");
            });

            modelBuilder.Entity<UnitMeasureModel>(entity =>
            {
                entity.HasKey(e => e.IdUnitMeasur)
                    .HasName("unit_measures_id_unit_measur_primary");

                entity.ToTable("UNIT_MEASURES");

                entity.Property(e => e.IdUnitMeasur)
                    .ValueGeneratedNever()
                    .HasColumnName("id_unit_measur");

                entity.Property(e => e.Abbreviation).HasColumnName("abbreviation");

                entity.Property(e => e.BaseId).HasColumnName("base_id");

                entity.Property(e => e.ConversionFactor)
                    .HasColumnType("decimal(8, 2)")
                    .HasColumnName("conversion_factor");

                entity.Property(e => e.Name)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("name");

                entity.Property(e => e.StatedAt)
                    .IsRequired()
                    .HasColumnName("stated_at")
                    .HasDefaultValueSql("('1')");

                entity.Property(e => e.Type).HasColumnName("type");
            });

            modelBuilder.Entity<UnitMeasuresXSupplyModel>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("UNIT_MEASURES_X_SUPPLY");

                entity.HasIndex(e => e.IdSupply, "unit_measures_x_supply_id_supply_unique")
                    .IsUnique();

                entity.HasIndex(e => e.IdUnitMeasure, "unit_measures_x_supply_id_unit_measure_unique")
                    .IsUnique();

                entity.Property(e => e.IdSupply).HasColumnName("id_supply");

                entity.Property(e => e.IdUnitMeasure).HasColumnName("id_unit_measure");

                entity.HasOne(d => d.IdSupplyNavigation)
                    .WithOne()
                    .HasForeignKey<UnitMeasuresXSupplyModel>(d => d.IdSupply)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("unit_measures_x_supply_id_supply_foreign");

                entity.HasOne(d => d.IdUnitMeasureNavigation)
                    .WithOne()
                    .HasForeignKey<UnitMeasuresXSupplyModel>(d => d.IdUnitMeasure)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("unit_measures_x_supply_id_unit_measure_foreign");
            });

            modelBuilder.Entity<UserModel>(entity =>
            {
                entity.HasKey(e => e.IdUser)
                    .HasName("users_id_user_primary");

                entity.ToTable("USERS");

                entity.HasIndex(e => e.DocumentNumber, "users_document_number_unique")
                    .IsUnique();

                entity.HasIndex(e => e.IdRole, "users_id_role_unique")
                    .IsUnique();

                entity.HasIndex(e => e.IdTypeDocument, "users_id_type_document_unique")
                    .IsUnique();

                entity.Property(e => e.IdUser)
                    .ValueGeneratedNever()
                    .HasColumnName("id_user");

                entity.Property(e => e.Address).HasColumnName("address");

                entity.Property(e => e.DocumentNumber)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("document_number");

                entity.Property(e => e.Email).HasColumnName("email");

                entity.Property(e => e.IdRole).HasColumnName("id_role");

                entity.Property(e => e.IdTypeDocument).HasColumnName("id_type_document");

                entity.Property(e => e.LastNames).HasColumnName("last_names");

                entity.Property(e => e.PasswordDigest).HasColumnName("password_digest");

                entity.Property(e => e.Phone).HasColumnName("phone");

                entity.Property(e => e.Surnames)
                    .HasMaxLength(255)
                    .HasColumnName("surnames")
                    .IsFixedLength();

                entity.HasOne(d => d.IdRoleNavigation)
                    .WithOne(p => p.User)
                    .HasForeignKey<UserModel>(d => d.IdRole)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("users_id_role_foreign");

                entity.HasOne(d => d.IdTypeDocumentNavigation)
                    .WithOne(p => p.User)
                    .HasForeignKey<UserModel>(d => d.IdTypeDocument)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("users_id_type_document_foreign");
            });

            modelBuilder.Entity<WarehouseModel>(entity =>
            {
                entity.HasKey(e => e.IdWarehouse)
                    .HasName("warehouse_id_warehouse_primary");

                entity.ToTable("WAREHOUSE");

                entity.Property(e => e.IdWarehouse)
                    .ValueGeneratedNever()
                    .HasColumnName("id_warehouse");

                entity.Property(e => e.Name)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("name");

                entity.Property(e => e.StatedAt)
                    .IsRequired()
                    .HasColumnName("stated_at")
                    .HasDefaultValueSql("('1')");

                entity.Property(e => e.TypeWarehouse)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("type_warehouse");

                entity.Property(e => e.Ubication)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("ubication");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
