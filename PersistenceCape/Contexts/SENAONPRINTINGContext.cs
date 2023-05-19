using DataCape.Models;
using Microsoft.EntityFrameworkCore;
using System.Reflection;

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

        public virtual DbSet<ClientModel> Clients { get; set; } = null!;
        public virtual DbSet<FinishModel> Finishes { get; set; } = null!;
        public virtual DbSet<GrammajeCaliberModel> GrammajeCalibers { get; set; } = null!;
        public virtual DbSet<ImpositionPlateModel> ImpositionPlates { get; set; } = null!;
        public virtual DbSet<LineatureModel> Lineatures { get; set; } = null!;
        public virtual DbSet<MachineModel> Machines { get; set; } = null!;
        public virtual DbSet<OrderProductionModel> OrderProductions { get; set; } = null!;
        public virtual DbSet<PaperCutModel> PaperCuts { get; set; } = null!;
        public virtual DbSet<PermissionModel> Permissions { get; set; } = null!;
        public virtual DbSet<PermissionsXRoleModel> PermissionsXRoles { get; set; } = null!;
        public virtual DbSet<ProductModel> Products { get; set; } = null!;
        public virtual DbSet<ProgramModel> Programs { get; set; } = null!;
        public virtual DbSet<ProviderModel> Providers { get; set; } = null!;
        public virtual DbSet<QuotationClientModel> QuotationClients { get; set; } = null!;
        public virtual DbSet<QuotationProviderModel> QuotationProviders { get; set; } = null!;
        public virtual DbSet<RoleModel> Roles { get; set; } = null!;
        public virtual DbSet<SubstrateModel> Substrates { get; set; } = null!;
        public virtual DbSet<SubstrateXQuotationClientModel> SubstrateXQuotationClients { get; set; } = null!;
        public virtual DbSet<SupplyModel> Supplies { get; set; } = null!;
        public virtual DbSet<SupplyCategoriesXSupplyModel> SupplyCategoriesXSupplies { get; set; } = null!;
        public virtual DbSet<SupplyCategoryModel> SupplyCategories { get; set; } = null!;
        public virtual DbSet<SupplyDetailModel> SupplyDetails { get; set; } = null!;
        public virtual DbSet<SupplyPictogramModel> SupplyPictograms { get; set; } = null!;
        public virtual DbSet<SupplyXProductModel> SupplyXProducts { get; set; } = null!;
        public virtual DbSet<SupplyXSupplyPictogramModel> SupplyXSupplyPictograms { get; set; } = null!;
        public virtual DbSet<TypeDocumentModel> TypeDocuments { get; set; } = null!;
        public virtual DbSet<TypeServiceModel> TypeServices { get; set; } = null!;
        public virtual DbSet<UnitMeasureModel> UnitMeasures { get; set; } = null!;
        public virtual DbSet<UnitMeasuresXSupplyModel> UnitMeasuresXSupplies { get; set; } = null!;
        public virtual DbSet<UserModel> Users { get; set; } = null!;
        public virtual DbSet<WarehouseModel> Warehouses { get; set; } = null!;
        public virtual DbSet<WarehouseTypeModel> WarehouseTypes { get; set; } = null!;

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:Collation", "Modern_Spanish_CI_AS");

            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());

            modelBuilder.Entity<ClientModel>(entity =>
            {
                entity.HasKey(e => e.IdClient)
                    .HasName("pk_CLIENTS");

                entity.ToTable("CLIENTS");

                entity.Property(e => e.IdClient).HasColumnName("id_client");

                entity.Property(e => e.Area)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("area");

                entity.Property(e => e.Center)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("center");

                entity.Property(e => e.Email)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("email");

                entity.Property(e => e.Name)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("name");

                entity.Property(e => e.Phone)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("phone");

                entity.Property(e => e.Regional)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("regional");

                entity.Property(e => e.StatedAt)
                    .IsRequired()
                    .HasColumnName("stated_at")
                    .HasDefaultValueSql("('1')");
            });

            modelBuilder.Entity<FinishModel>(entity =>
            {
                entity.HasKey(e => e.IdFinish)
                    .HasName("pk_FINISHES");

                entity.ToTable("FINISHES");

                entity.Property(e => e.IdFinish).HasColumnName("id_finish");

                entity.Property(e => e.FinishName)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("finish_name");

                entity.Property(e => e.StatedAt)
                    .IsRequired()
                    .HasColumnName("stated_at")
                    .HasDefaultValueSql("('1')");
            });

            modelBuilder.Entity<GrammajeCaliberModel>(entity =>
            {
                entity.HasKey(e => e.IdGrammajeCaliber);

                entity.ToTable("GRAMMAJE_CALIBER");

                entity.Property(e => e.IdGrammajeCaliber)
                    .ValueGeneratedNever()
                    .HasColumnName("id_grammaje_caliber");

                entity.Property(e => e.GrammajeCaliber1)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("grammaje_caliber");

                entity.Property(e => e.TypeGrammajeCaliber)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("type_grammaje_caliber");
            });

            modelBuilder.Entity<ImpositionPlateModel>(entity =>
            {
                entity.HasKey(e => e.IdImpositionPlate);

                entity.ToTable("IMPOSITION_PLATE");

                entity.Property(e => e.IdImpositionPlate).HasColumnName("id_imposition_plate");

                entity.Property(e => e.ImpositionPlateName)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("imposition_plate_name");

                entity.Property(e => e.Scheme).HasColumnName("scheme");

                entity.Property(e => e.StatedAt)
                    .IsRequired()
                    .HasColumnName("stated_at")
                    .HasDefaultValueSql("((1))");
            });

            modelBuilder.Entity<LineatureModel>(entity =>
            {
                entity.HasKey(e => e.IdLineature);

                entity.ToTable("LINEATURE");

                entity.Property(e => e.IdLineature).HasColumnName("id_lineature");

                entity.Property(e => e.Lineature1)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("lineature");

                entity.Property(e => e.Other)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("other");

                entity.Property(e => e.StatedAt)
                    .IsRequired()
                    .HasColumnName("stated_at")
                    .HasDefaultValueSql("((1))");

                entity.Property(e => e.TypePoint)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("type_point");
            });

            modelBuilder.Entity<MachineModel>(entity =>
            {
                entity.HasKey(e => e.IdMachine)
                    .HasName("pk_MACHINES");

                entity.ToTable("MACHINES");

                entity.Property(e => e.IdMachine).HasColumnName("id_machine");

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
                    .HasMaxLength(90)
                    .IsUnicode(false)
                    .HasColumnName("name");

                entity.Property(e => e.StatedAt)
                    .IsRequired()
                    .HasColumnName("stated_at")
                    .HasDefaultValueSql("('1')");
            });

            modelBuilder.Entity<OrderProductionModel>(entity =>
            {
                entity.HasKey(e => e.IdOrderProduction)
                    .HasName("pk_Tbl_0");

                entity.ToTable("ORDER_PRODUCTION");

                entity.Property(e => e.IdOrderProduction).HasColumnName("id_order_production");

                entity.Property(e => e.ColorProfile)
                    .HasMaxLength(255)
                    .HasColumnName("color_profile");

                entity.Property(e => e.IdGrammage).HasColumnName("id_grammage");

                entity.Property(e => e.IdLineature).HasColumnName("id_lineature");

                entity.Property(e => e.IdPaperCutSize).HasColumnName("id_paper_cut_size");

                entity.Property(e => e.IdPlateImposition).HasColumnName("id_plate_imposition");

                entity.Property(e => e.IdProgram).HasColumnName("id_program");

                entity.Property(e => e.IdQuotationClient).HasColumnName("id_quotation_client");

                entity.Property(e => e.IdUser).HasColumnName("id_user");

                entity.Property(e => e.Image).HasColumnName("image");

                entity.Property(e => e.Indented).HasColumnName("indented");

                entity.Property(e => e.InkCode)
                    .HasMaxLength(100)
                    .HasColumnName("ink_code");

                entity.Property(e => e.MaterialReception)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("material_reception");

                entity.Property(e => e.Observations)
                    .HasMaxLength(300)
                    .HasColumnName("observations");

                entity.Property(e => e.OrderStatus).HasColumnName("order_status");

                entity.Property(e => e.ProgramVersion)
                    .HasMaxLength(255)
                    .HasColumnName("program_version");

                entity.Property(e => e.SpecialInk)
                    .HasMaxLength(255)
                    .HasColumnName("special_ink");

                entity.Property(e => e.StatedAt)
                    .IsRequired()
                    .HasColumnName("stated_at")
                    .HasDefaultValueSql("('1')");

                entity.HasOne(d => d.IdGrammageNavigation)
                    .WithMany(p => p.OrderProductions)
                    .HasForeignKey(d => d.IdGrammage)
                    .HasConstraintName("FK_ORDER_PRODUCTION_GRAMMAJE_CALIBER");

                entity.HasOne(d => d.IdLineatureNavigation)
                    .WithMany(p => p.OrderProductions)
                    .HasForeignKey(d => d.IdLineature)
                    .HasConstraintName("FK_ORDER_PRODUCTION_LINEATURE");

                entity.HasOne(d => d.IdPaperCutSizeNavigation)
                    .WithMany(p => p.OrderProductions)
                    .HasForeignKey(d => d.IdPaperCutSize)
                    .HasConstraintName("FK_ORDER_PRODUCTION_PAPER_CUT");

                entity.HasOne(d => d.IdPlateImpositionNavigation)
                    .WithMany(p => p.OrderProductions)
                    .HasForeignKey(d => d.IdPlateImposition)
                    .HasConstraintName("FK_ORDER_PRODUCTION_IMPOSITION_PLATE");

                entity.HasOne(d => d.IdProgramNavigation)
                    .WithMany(p => p.OrderProductions)
                    .HasForeignKey(d => d.IdProgram)
                    .HasConstraintName("FK_ORDER_PRODUCTION_PROGRAM");

                entity.HasOne(d => d.IdQuotationClientNavigation)
                    .WithMany(p => p.OrderProductions)
                    .HasForeignKey(d => d.IdQuotationClient)
                    .HasConstraintName("id_quotation_products");

                entity.HasOne(d => d.IdUserNavigation)
                    .WithMany(p => p.OrderProductions)
                    .HasForeignKey(d => d.IdUser)
                    .HasConstraintName("id_user");
            });

            modelBuilder.Entity<PaperCutModel>(entity =>
            {
                entity.HasKey(e => e.IdPaperCut);

                entity.ToTable("PAPER_CUT");

                entity.Property(e => e.IdPaperCut).HasColumnName("id_paper_cut");

                entity.Property(e => e.PaperCut1)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("paper_cut");

                entity.Property(e => e.StatedAt)
                    .IsRequired()
                    .HasColumnName("stated_at")
                    .HasDefaultValueSql("((1))");
            });

            modelBuilder.Entity<PermissionModel>(entity =>
            {
                entity.HasKey(e => e.IdPermission)
                    .HasName("permissions_id_permission_primary");

                entity.ToTable("PERMISSIONS");

                entity.Property(e => e.IdPermission).HasColumnName("id_permission");

                entity.Property(e => e.Permission1)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("permission");

                entity.Property(e => e.StatedAt)
                    .IsRequired()
                    .HasColumnName("stated_at")
                    .HasDefaultValueSql("('1')");
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

            modelBuilder.Entity<ProductModel>(entity =>
            {
                entity.HasKey(e => e.IdProduct)
                    .HasName("pk_PRODUCTS");

                entity.ToTable("PRODUCTS");

                entity.Property(e => e.IdProduct).HasColumnName("id_product");

                entity.Property(e => e.Characteristics)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("characteristics");

                entity.Property(e => e.IdSupply).HasColumnName("id_supply");

                entity.Property(e => e.Name)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("name");

                entity.Property(e => e.StatedAt)
                    .IsRequired()
                    .HasColumnName("stated_at")
                    .HasDefaultValueSql("('1')");

                entity.Property(e => e.TypeProduct)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("type_product");
            });

            modelBuilder.Entity<ProgramModel>(entity =>
            {
                entity.HasKey(e => e.IdProgram);

                entity.ToTable("PROGRAM");

                entity.Property(e => e.IdProgram).HasColumnName("id_program");

                entity.Property(e => e.ProgramName).HasColumnName("program_name");

                entity.Property(e => e.StatedAt)
                    .IsRequired()
                    .HasColumnName("stated_at")
                    .HasDefaultValueSql("((1))");
            });

            modelBuilder.Entity<ProviderModel>(entity =>
            {
                entity.HasKey(e => e.IdProvider)
                    .HasName("pk_PROVIDERS");

                entity.ToTable("PROVIDERS");

                entity.Property(e => e.IdProvider).HasColumnName("id_provider");

                entity.Property(e => e.CompanyAddress)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("company_address");

                entity.Property(e => e.Email)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("email");

                entity.Property(e => e.NameCompany)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("name_company");

                entity.Property(e => e.NitCompany).HasColumnName("nit_company");

                entity.Property(e => e.Phone)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("phone");

                entity.Property(e => e.StatedAt)
                    .IsRequired()
                    .HasColumnName("stated_at")
                    .HasDefaultValueSql("('1')");
            });

            modelBuilder.Entity<QuotationClientModel>(entity =>
            {
                entity.HasKey(e => e.IdQuotationClient)
                    .HasName("pk_QUOTATION_PRODUCTS");

                entity.ToTable("QUOTATION_CLIENTS");

                entity.Property(e => e.IdQuotationClient).HasColumnName("id_quotation_client");

                entity.Property(e => e.DateOrde)
                    .HasColumnType("date")
                    .HasColumnName("date_orde");

                entity.Property(e => e.DeliverDate)
                    .HasColumnType("date")
                    .HasColumnName("deliver_date");

                entity.Property(e => e.FullValue).HasColumnName("full_value");

                entity.Property(e => e.IdClient).HasColumnName("id_client");

                entity.Property(e => e.IdFinishes).HasColumnName("id_finishes");

                entity.Property(e => e.IdMachine).HasColumnName("id_machine");

                entity.Property(e => e.IdProduct).HasColumnName("id_product");

                entity.Property(e => e.IdSubstrate).HasColumnName("id_substrate");

                entity.Property(e => e.IdTypeService).HasColumnName("id_type_service");

                entity.Property(e => e.IdUser).HasColumnName("id_user");

                entity.Property(e => e.InkQuantity).HasColumnName("ink_quantity");

                entity.Property(e => e.NumberOfPages).HasColumnName("number_of_pages");

                entity.Property(e => e.ProductHigh).HasColumnName("product_high");

                entity.Property(e => e.ProductQuantity).HasColumnName("product_quantity");

                entity.Property(e => e.ProductWidth).HasColumnName("product_width");

                entity.Property(e => e.QuotationStatus).HasColumnName("quotation_status");

                entity.Property(e => e.StatedAt)
                    .IsRequired()
                    .HasColumnName("stated_at")
                    .HasDefaultValueSql("('1')");

                entity.Property(e => e.TechnicalSpecifications)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("technical_specifications");

                entity.Property(e => e.UnitValue).HasColumnName("unit_value");

                entity.HasOne(d => d.IdClientNavigation)
                    .WithMany(p => p.QuotationClients)
                    .HasForeignKey(d => d.IdClient)
                    .HasConstraintName("id_client");

                entity.HasOne(d => d.IdFinishesNavigation)
                    .WithMany(p => p.QuotationClients)
                    .HasForeignKey(d => d.IdFinishes)
                    .HasConstraintName("id_finish");

                entity.HasOne(d => d.IdMachineNavigation)
                    .WithMany(p => p.QuotationClients)
                    .HasForeignKey(d => d.IdMachine)
                    .HasConstraintName("id_machine");

                entity.HasOne(d => d.IdProductNavigation)
                    .WithMany(p => p.QuotationClients)
                    .HasForeignKey(d => d.IdProduct)
                    .HasConstraintName("id_product");

                entity.HasOne(d => d.IdTypeServiceNavigation)
                    .WithMany(p => p.QuotationClients)
                    .HasForeignKey(d => d.IdTypeService)
                    .HasConstraintName("id_type_service");

                entity.HasOne(d => d.IdUserNavigation)
                    .WithMany(p => p.QuotationClients)
                    .HasForeignKey(d => d.IdUser)
                    .HasConstraintName("FK_QUOTATION_CLIENTS_USERS");
            });

            modelBuilder.Entity<QuotationProviderModel>(entity =>
            {
                entity.HasKey(e => e.IdQuotationProvider)
                    .HasName("pk_QUOTATION_PROVIDERS");

                entity.ToTable("QUOTATION_PROVIDERS");

                entity.Property(e => e.IdQuotationProvider).HasColumnName("id_quotation_provider");

                entity.Property(e => e.Date)
                    .HasColumnType("date")
                    .HasColumnName("date");

                entity.Property(e => e.FullValue).HasColumnName("full_value");

                entity.Property(e => e.IdProvider).HasColumnName("id_provider");

                entity.Property(e => e.QuotationFile).HasColumnName("quotation_file");

                entity.Property(e => e.StatedAt)
                    .IsRequired()
                    .HasColumnName("stated_at")
                    .HasDefaultValueSql("('1')");

                entity.HasOne(d => d.IdProviderNavigation)
                    .WithMany(p => p.QuotationProviders)
                    .HasForeignKey(d => d.IdProvider)
                    .HasConstraintName("id_provider");
            });

            modelBuilder.Entity<RoleModel>(entity =>
            {
                entity.HasKey(e => e.IdRole)
                    .HasName("roles_id_role_primary");

                entity.ToTable("ROLES");

                entity.Property(e => e.IdRole).HasColumnName("id_role");

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

            modelBuilder.Entity<SubstrateModel>(entity =>
            {
                entity.HasKey(e => e.IdSubstrate)
                    .HasName("pk_SUBSTRATES");

                entity.ToTable("SUBSTRATES");

                entity.Property(e => e.IdSubstrate).HasColumnName("id_substrate");

                entity.Property(e => e.StatedAt).HasColumnName("stated_at");

                entity.Property(e => e.SubstratumName)
                    .HasMaxLength(200)
                    .IsUnicode(false)
                    .HasColumnName("substratum_name");
            });

            modelBuilder.Entity<SubstrateXQuotationClientModel>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("SUBSTRATE_X_QUOTATION_CLIENT");

                entity.Property(e => e.IdQuotationClient).HasColumnName("id_quotation_client");

                entity.Property(e => e.IdSubstrate).HasColumnName("id_substrate");

                entity.HasOne(d => d.IdQuotationClientNavigation)
                    .WithMany()
                    .HasForeignKey(d => d.IdQuotationClient)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_SUBSTRATE_X_QUOTATION_CLIENT_QUOTATION_CLIENTS");

                entity.HasOne(d => d.IdSubstrateNavigation)
                    .WithMany()
                    .HasForeignKey(d => d.IdSubstrate)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_SUBSTRATE_X_QUOTATION_CLIENT_SUBSTRATES");
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

            modelBuilder.Entity<SupplyDetailModel>(entity =>
            {
                entity.HasKey(e => e.IdSupplyDetails)
                    .HasName("pk_SUPPLY_DETAILS");

                entity.ToTable("SUPPLY_DETAILS");

                entity.Property(e => e.IdSupplyDetails).HasColumnName("id_supply_details");

                entity.Property(e => e.ActualQuantity).HasColumnName("actual_quantity");

                entity.Property(e => e.Batch)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("batch");

                entity.Property(e => e.EntryDate)
                    .HasColumnType("datetime")
                    .HasColumnName("entry_date");

                entity.Property(e => e.ExpirationDate)
                    .HasColumnType("datetime")
                    .HasColumnName("expiration_date");

                entity.Property(e => e.IdProvider).HasColumnName("id_provider");

                entity.Property(e => e.IdSupply).HasColumnName("id_supply");

                entity.Property(e => e.InitialQuantity).HasColumnName("initial_quantity");

                entity.Property(e => e.StatedAt)
                    .IsRequired()
                    .HasColumnName("stated_at")
                    .HasDefaultValueSql("('1')");

                entity.Property(e => e.SupplyCost)
                    .HasColumnType("decimal(8, 2)")
                    .HasColumnName("supply_cost");

                entity.HasOne(d => d.IdProviderNavigation)
                    .WithMany(p => p.SupplyDetails)
                    .HasForeignKey(d => d.IdProvider)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_SUPPLY_DETAILS_PROVIDERS");

                entity.HasOne(d => d.IdSupplyNavigation)
                    .WithMany(p => p.SupplyDetails)
                    .HasForeignKey(d => d.IdSupply)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("id_supply");
            });

            modelBuilder.Entity<SupplyPictogramModel>(entity =>
            {
                entity.HasKey(e => e.IdPictogram)
                    .HasName("supply_pictograms_id_pictogram_primary");

                entity.ToTable("SUPPLY_PICTOGRAMS");

                entity.Property(e => e.IdPictogram).HasColumnName("id_pictogram");

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

            modelBuilder.Entity<SupplyXProductModel>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("SUPPLY_X_PRODUCT");

                entity.Property(e => e.IdProduct).HasColumnName("id_product");

                entity.Property(e => e.IdSupply).HasColumnName("id_supply");

                entity.HasOne(d => d.IdProductNavigation)
                    .WithMany()
                    .HasForeignKey(d => d.IdProduct)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_SUPPLY_X_PRODUCT_PRODUCTS");

                entity.HasOne(d => d.IdSupplyNavigation)
                    .WithMany()
                    .HasForeignKey(d => d.IdSupply)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_SUPPLY_X_PRODUCT_SUPPLIES");
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

                entity.Property(e => e.IdTypeDocument).HasColumnName("id_type_document");

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

            modelBuilder.Entity<TypeServiceModel>(entity =>
            {
                entity.HasKey(e => e.IdTypeService)
                    .HasName("pk_TYPE_SERVICE");

                entity.ToTable("TYPE_SERVICE");

                entity.Property(e => e.IdTypeService).HasColumnName("id_type_service");

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

                entity.Property(e => e.IdUnitMeasur).HasColumnName("id_unit_measur");

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

                entity.Property(e => e.IdUser).HasColumnName("id_user");

                entity.Property(e => e.Address)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .HasColumnName("address");

                entity.Property(e => e.DocumentNumber)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("document_number");

                entity.Property(e => e.Email)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .HasColumnName("email");

                entity.Property(e => e.IdRole).HasColumnName("id_role");

                entity.Property(e => e.IdTypeDocument).HasColumnName("id_type_document");

                entity.Property(e => e.LastNames)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .HasColumnName("last_names");

                entity.Property(e => e.PasswordDigest)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .HasColumnName("password_digest");

                entity.Property(e => e.Phone)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .HasColumnName("phone");

                entity.Property(e => e.StatedAt)
                    .IsRequired()
                    .HasColumnName("stated_at")
                    .HasDefaultValueSql("('1')");

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

                entity.HasIndex(e => e.IdTypeWarehouse, "warehause_id_type_warehouse_unique")
                    .IsUnique();

                entity.Property(e => e.IdWarehouse).HasColumnName("id_warehouse");

                entity.Property(e => e.IdTypeWarehouse).HasColumnName("id_type_warehouse");

                entity.Property(e => e.Name)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("name");

                entity.Property(e => e.StatedAt)
                    .IsRequired()
                    .HasColumnName("stated_at")
                    .HasDefaultValueSql("('1')");

                entity.Property(e => e.Ubication)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("ubication");

                
            });

            modelBuilder.Entity<WarehouseTypeModel>(entity =>
            {
                entity.HasKey(e => e.IdTypeWarehouse)
                    .HasName("pk_Tbl");

                entity.ToTable("WAREHOUSE_TYPE");

                entity.Property(e => e.IdTypeWarehouse).HasColumnName("id_type_warehouse");

                entity.Property(e => e.Description)
                    .IsUnicode(false)
                    .HasColumnName("description");

                entity.Property(e => e.Nametype)
                    .IsUnicode(false)
                    .HasColumnName("nametype");

                entity.Property(e => e.StatedAt)
                    .IsRequired()
                    .HasColumnName("stated_at")
                    .HasDefaultValueSql("('1')");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
