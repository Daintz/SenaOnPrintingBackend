using System;
using System.Collections.Generic;
using DataCape;
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

        public virtual DbSet<ClientModel> Clients { get; set; } = null!;
        public virtual DbSet<FinishModel> Finishes { get; set; } = null!;
        public virtual DbSet<FinishXQuotationClientDetailModel> FinishXQuotationClientDetails { get; set; } = null!;
        public virtual DbSet<GrammageCaliberModel> GrammageCalibers { get; set; } = null!;
        public virtual DbSet<GrammageCaliberXQuotationClientDetailModel> GrammageCaliberXQuotationClientDetails { get; set; } = null!;
        public virtual DbSet<ImpositionPlanchModel> ImpositionPlanches { get; set; } = null!;
        public virtual DbSet<ImpositionPlanchXOrderProductionModel> ImpositionPlanchXOrderProductions { get; set; } = null!;
        public virtual DbSet<LineatureModel> Lineatures { get; set; } = null!;
        public virtual DbSet<LineatureXOrderProductionModel> LineatureXOrderProductions { get; set; } = null!;
        public virtual DbSet<MachineModel> Machines { get; set; } = null!;
        public virtual DbSet<MachinesXQuotationClientModel> MachinesXQuotationClients { get; set; } = null!;
        public virtual DbSet<OrderProductionModel> OrderProductions { get; set; } = null!;
        public virtual DbSet<PaperCutModel> PaperCuts { get; set; } = null!;
        public virtual DbSet<PermissionsByRoleModel> PermissionsByRoles { get; set; } = null!;
        public virtual DbSet<ProductModel> Products { get; set; } = null!;
        public virtual DbSet<ProviderModel> Providers { get; set; } = null!;
        public virtual DbSet<QuotationClientModel> QuotationClients { get; set; } = null!;
        public virtual DbSet<QuotationClientDetailModel> QuotationClientDetails { get; set; } = null!;
        public virtual DbSet<QuotationProviderModel> QuotationProviders { get; set; } = null!;
        public virtual DbSet<RoleModel> Roles { get; set; } = null!;
        public virtual DbSet<SubstrateModel> Substrates { get; set; } = null!;
        public virtual DbSet<SubstrateXQuotationClientDetailModel> SubstrateXQuotationClientDetails { get; set; } = null!;
        public virtual DbSet<SupplyModel> Supplies { get; set; } = null!;
        public virtual DbSet<SupplyCategoriesXSupplyModel> SupplyCategoriesXSupplies { get; set; } = null!;
        public virtual DbSet<SupplyCategoryModel> SupplyCategories { get; set; } = null!;
        public virtual DbSet<SupplyDetailModel> SupplyDetails { get; set; } = null!;
        public virtual DbSet<SupplyPictogramModel> SupplyPictograms { get; set; } = null!;
        public virtual DbSet<SupplyXProductModel> SupplyXProducts { get; set; } = null!;
        public virtual DbSet<SupplyXSupplyPictogramModel> SupplyXSupplyPictograms { get; set; } = null!;

        public virtual DbSet<TypeServiceModel> TypeServices { get; set; } = null!;
        public virtual DbSet<TypeDocumentModel> TypeDocuments { get; set; } = null!;

        public virtual DbSet<UserModel> Users { get; set; } = null!;
        public virtual DbSet<UnitMeasureModel> UnitMeasures { get; set; } = null!;
        public virtual DbSet<WarehouseModel> Warehouses { get; set; } = null!;
        public virtual DbSet<WarehouseTypeModel> WarehouseTypes { get; set; } = null!;

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

            modelBuilder.Entity<ClientModel>(entity =>
            {
                entity.ToTable("clients");

                entity.HasIndex(e => e.Email, "UQ_clients_AB6E6164160CA661")
                    .IsUnique();

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Area)
                    .HasMaxLength(250)
                    .IsUnicode(false)
                    .HasColumnName("area");

                entity.Property(e => e.Center)
                    .HasMaxLength(200)
                    .IsUnicode(false)
                    .HasColumnName("center");

                entity.Property(e => e.Email)
                    .HasMaxLength(110)
                    .IsUnicode(false)
                    .HasColumnName("email");

                entity.Property(e => e.Name)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("name");

                entity.Property(e => e.Phone)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("phone");

                entity.Property(e => e.Regional)
                    .HasMaxLength(250)
                    .IsUnicode(false)
                    .HasColumnName("regional");

                entity.Property(e => e.StatedAt)
                    .HasColumnName("stated_at")
                    .HasDefaultValueSql("((1))");


            });

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

            modelBuilder.Entity<FinishXQuotationClientDetailModel>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("finish_x_quotation_client_detail");

                entity.Property(e => e.FinishId).HasColumnName("finish_id");

                entity.Property(e => e.QuotationClientDetailId).HasColumnName("quotation_client_detail_id");

                entity.HasOne(d => d.Finish)
                    .WithMany()
                    .HasForeignKey(d => d.FinishId)
                    .HasConstraintName("FK_finish_x_finis_1F98B2C1");

                entity.HasOne(d => d.QuotationClientDetail)
                    .WithMany()
                    .HasForeignKey(d => d.QuotationClientDetailId)
                    .HasConstraintName("FK_finish_x_quota_1EA48E88");
            });

            modelBuilder.Entity<GrammageCaliberModel>(entity =>
            {
                entity.ToTable("grammage_caliber");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Name)
                    .HasMaxLength(150)
                    .IsUnicode(false)
                    .HasColumnName("name");

                entity.Property(e => e.StatedAt)
                    .HasColumnName("stated_at")
                    .HasDefaultValueSql("((1))");

                entity.Property(e => e.Type)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("type");
            });

            modelBuilder.Entity<GrammageCaliberXQuotationClientDetailModel>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("grammage_caliber_x_quotation_client_detail");

                entity.Property(e => e.GrammageCaliberId).HasColumnName("grammage_caliber_id");

                entity.Property(e => e.OrderProductionId).HasColumnName("order_production_id");

                entity.HasOne(d => d.GrammageCaliber)
                    .WithMany()
                    .HasForeignKey(d => d.GrammageCaliberId)
                    .HasConstraintName("FK_grammage_gramm_22751F6C");

                entity.HasOne(d => d.OrderProduction)
                    .WithMany()
                    .HasForeignKey(d => d.OrderProductionId)
                    .HasConstraintName("FK_grammage_order_2180FB33");
            });

            modelBuilder.Entity<ImpositionPlanchModel>(entity =>
            {
                entity.ToTable("imposition_planch");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Name)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("name");

                entity.Property(e => e.StatedAt)
                    .HasColumnName("stated_at")
                    .HasDefaultValueSql("((1))");
            });

            modelBuilder.Entity<ImpositionPlanchXOrderProductionModel>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("imposition_planch_x_order_production");

                entity.Property(e => e.ImpositionPlanchId).HasColumnName("imposition_planch_id");

                entity.Property(e => e.OrderProductionId).HasColumnName("order_production_id");

                entity.HasOne(d => d.ImpositionPlanch)
                    .WithMany()
                    .HasForeignKey(d => d.ImpositionPlanchId)
                    .HasConstraintName("FK_impositioimpos_25518C17");

                entity.HasOne(d => d.OrderProduction)
                    .WithMany()
                    .HasForeignKey(d => d.OrderProductionId)
                    .HasConstraintName("FK_impositioorder_245D67DE");
            });

            modelBuilder.Entity<LineatureModel>(entity =>
            {
                entity.ToTable("lineature");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Lineature)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("lineature");

                entity.Property(e => e.StatedAt)
                    .HasColumnName("stated_at")
                    .HasDefaultValueSql("((1))");


            });

            modelBuilder.Entity<LineatureXOrderProductionModel>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("lineature_x_order_production");

                entity.Property(e => e.LineatureId).HasColumnName("lineature_id");

                entity.Property(e => e.OrderProductionId).HasColumnName("order_production_id");

                entity.HasOne(d => d.Lineature)
                    .WithMany()
                    .HasForeignKey(d => d.LineatureId)
                    .HasConstraintName("FK_lineaturelinea_282DF8C2");

                entity.HasOne(d => d.OrderProduction)
                    .WithMany()
                    .HasForeignKey(d => d.OrderProductionId)
                    .HasConstraintName("FK_lineatureorder_2739D489");
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

            modelBuilder.Entity<MachinesXQuotationClientModel>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("machines_x_quotation_client");

                entity.Property(e => e.MachineId).HasColumnName("machine_id");

                entity.Property(e => e.QuotationClientId).HasColumnName("quotation_client_id");

                entity.HasOne(d => d.Machine)
                    .WithMany()
                    .HasForeignKey(d => d.MachineId)
                    .HasConstraintName("FK_machines_machi_2B0A656D");

                entity.HasOne(d => d.QuotationClient)
                    .WithMany()
                    .HasForeignKey(d => d.QuotationClientId)
                    .HasConstraintName("FK_machines_quota_2A164134");
            });

            modelBuilder.Entity<OrderProductionModel>(entity =>
            {
                entity.ToTable("order_production");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.ColorProfile)
                    .HasMaxLength(255)
                    .HasColumnName("color_profile");

                entity.Property(e => e.IdPaperCut).HasColumnName("id_paper_cut");

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

                entity.Property(e => e.Program)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("program");

                entity.Property(e => e.ProgramVersion)
                    .HasMaxLength(255)
                    .HasColumnName("program_version");
                entity.Property(e => e.TypePoint)
                    .HasMaxLength(150)
                    .IsUnicode(false)
                    .HasColumnName("type_point");
                entity.Property(e => e.Scheme).HasColumnName("scheme");


                entity.Property(e => e.QuotationClientDetailId).HasColumnName("quotation_client_detail_id");

                entity.Property(e => e.SpecialInk)
                    .HasMaxLength(255)
                    .HasColumnName("special_ink");

                entity.Property(e => e.StatedAt).HasColumnName("stated_at");

                entity.Property(e => e.UserId).HasColumnName("user_id");

                entity.HasOne(d => d.IdPaperCutNavigation)
                    .WithMany(p => p.OrderProductions)
                    .HasForeignKey(d => d.IdPaperCut)
                    .HasConstraintName("FK_order_proid_pa_1CBC4616");

                entity.HasOne(d => d.QuotationClientDetail)
                    .WithMany(p => p.OrderProductions)
                    .HasForeignKey(d => d.QuotationClientDetailId)
                    .HasConstraintName("FK_order_proquota_1AD3FDA4");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.OrderProductions)
                    .HasForeignKey(d => d.UserId)
                    .HasConstraintName("FK_order_prouser__1BC821DD");
            });

            modelBuilder.Entity<PaperCutModel>(entity =>
            {
                entity.ToTable("paper_cut");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Name)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("name");

                entity.Property(e => e.StatedAt)
                    .HasColumnName("stated_at")
                    .HasDefaultValueSql("((1))");

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
                    .HasConstraintName("FK_permissiopermi_3C69FB99");

                entity.HasOne(d => d.Role)
                    .WithMany(p => p.PermissionsByRoles)
                    .HasForeignKey(d => d.RoleId)
                    .HasConstraintName("FK_permissiorole__3D5E1FD2");
            });

            modelBuilder.Entity<ProductModel>(entity =>
            {
                entity.ToTable("products");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Characteristics)
                    .HasColumnType("text")
                    .HasColumnName("characteristics");

                entity.Property(e => e.Name)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("name");

                entity.Property(e => e.StatedAt)
                    .HasColumnName("stated_at")
                    .HasDefaultValueSql("((1))");

                entity.Property(e => e.TypeProduct)
                    .HasMaxLength(150)
                    .IsUnicode(false)
                    .HasColumnName("type_product");
            });

            modelBuilder.Entity<ProviderModel>(entity =>
            {
                entity.ToTable("providers");


                entity.HasIndex(e => e.Email, "UQ_provider_AB6E6164A71623EA");

                entity.HasIndex(e => e.Email, "UQ_provider_AB6E6164B50CE394")

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

            modelBuilder.Entity<QuotationClientModel>(entity =>
            {
                entity.ToTable("quotation_clients");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.ClientId).HasColumnName("client_id");

                entity.Property(e => e.DeliverDate)
                    .HasColumnType("date")
                    .HasColumnName("deliver_date");

                entity.Property(e => e.OrderDate)
                    .HasColumnType("date")
                    .HasColumnName("order_date");

                entity.Property(e => e.QuotationStatus).HasColumnName("quotation_status");

                entity.Property(e => e.StatedAt)
                    .HasColumnName("stated_at")
                    .HasDefaultValueSql("((1))");

                entity.Property(e => e.TypeServiceId).HasColumnName("type_service_id");

                entity.Property(e => e.UserId).HasColumnName("user_id");

                entity.HasOne(d => d.Client)
                    .WithMany(p => p.QuotationClients)
                    .HasForeignKey(d => d.ClientId)
                    .HasConstraintName("FK_quotationclien_0E6E26BF");

                entity.HasOne(d => d.TypeService)
                    .WithMany(p => p.QuotationClients)
                    .HasForeignKey(d => d.TypeServiceId)
                    .HasConstraintName("FK_quotationtype__0F624AF8");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.QuotationClients)
                    .HasForeignKey(d => d.UserId)
                    .HasConstraintName("FK_quotationuser__0D7A0286");
            });

            modelBuilder.Entity<QuotationClientDetailModel>(entity =>
            {
                entity.ToTable("quotation_client_details");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.FullValue).HasColumnName("full_value");

                entity.Property(e => e.InkQuantity).HasColumnName("ink_quantity");

                entity.Property(e => e.NumberOfPages).HasColumnName("number_of_pages");

                entity.Property(e => e.ProductHeight).HasColumnName("product_height");

                entity.Property(e => e.ProductId).HasColumnName("product_id");

                entity.Property(e => e.ProductQuantity).HasColumnName("product_quantity");

                entity.Property(e => e.ProductWidth).HasColumnName("product_width");

                entity.Property(e => e.QuotationClientId).HasColumnName("quotation_client_id");

                entity.Property(e => e.StatedAt)
                    .HasColumnName("stated_at")
                    .HasDefaultValueSql("((1))");

                entity.Property(e => e.TechnicalSpecifications)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("technical_specifications");

                entity.Property(e => e.UnitValue).HasColumnName("unit_value");

                entity.HasOne(d => d.Product)
                    .WithMany(p => p.QuotationClientDetails)
                    .HasForeignKey(d => d.ProductId)
                    .HasConstraintName("FK_quotationprodu_14270015");

                entity.HasOne(d => d.QuotationClient)
                    .WithMany(p => p.QuotationClientDetails)
                    .HasForeignKey(d => d.QuotationClientId)
                    .HasConstraintName("FK_quotationquota_1332DBDC");
            });

            modelBuilder.Entity<QuotationProviderModel>(entity =>
            {
                entity.ToTable("quotation_providers");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.FullValue).HasColumnName("full_value");

                entity.Property(e => e.ProviderId).HasColumnName("provider_id");

                entity.Property(e => e.QuotationDate)
                    .HasColumnType("date")
                    .HasColumnName("quotation_date");

                entity.Property(e => e.QuotationFile).HasColumnName("quotation_file");

                entity.Property(e => e.StatedAt)
                    .HasColumnName("stated_at")
                    .HasDefaultValueSql("((1))");

                entity.HasOne(d => d.Provider)
                    .WithMany(p => p.QuotationProviders)
                    .HasForeignKey(d => d.ProviderId)
                    .HasConstraintName("FK_quotationprovi_2DE6D218");

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

            modelBuilder.Entity<SubstrateModel>(entity =>
            {
                entity.ToTable("substrates");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Name)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("name");

                entity.Property(e => e.StatedAt)
                    .HasColumnName("stated_at")
                    .HasDefaultValueSql("((1))");
            });

            modelBuilder.Entity<SubstrateXQuotationClientDetailModel>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("substrate_x_quotation_client_detail");

                entity.Property(e => e.QuotationClientDetailId).HasColumnName("quotation_client_detail_id");

                entity.Property(e => e.SubstrateId).HasColumnName("substrate_id");

                entity.HasOne(d => d.QuotationClientDetail)
                    .WithMany()
                    .HasForeignKey(d => d.QuotationClientDetailId)
                    .HasConstraintName("FK_substratequota_30C33EC3");

                entity.HasOne(d => d.Substrate)
                    .WithMany()
                    .HasForeignKey(d => d.SubstrateId)
                    .HasConstraintName("FK_substratesubst_31B762FC");
            });

            modelBuilder.Entity<SupplyModel>(entity =>
            {
                entity.ToTable("supplies");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Advices)
                    .HasColumnType("text")
                    .HasColumnName("advices");

                entity.Property(e => e.AverageCost)
                    .HasColumnType("decimal(8, 2)")
                    .HasColumnName("average_cost");

                entity.Property(e => e.DangerIndicators)
                    .HasColumnType("text")
                    .HasColumnName("danger_indicators");

                entity.Property(e => e.Name)
                    .HasMaxLength(200)
                    .IsUnicode(false)
                    .HasColumnName("name");

                entity.Property(e => e.Quantity).HasColumnName("quantity");

                entity.Property(e => e.SortingWord).HasColumnName("sorting_word");

                entity.Property(e => e.StatedAt)
                    .HasColumnName("stated_at")
                    .HasDefaultValueSql("((1))");

                entity.Property(e => e.SupplyType).HasColumnName("supply_type");

                entity.Property(e => e.UseInstructions)
                    .HasColumnType("text")
                    .HasColumnName("use_instructions");

                entity.Property(e => e.WarehouseId).HasColumnName("warehouse_id");

                entity.HasOne(d => d.Warehouse)
                    .WithMany(p => p.Supplies)
                    .HasForeignKey(d => d.WarehouseId)
                    .HasConstraintName("FK_supplieswareho_5BE2A6F2");
            });

            modelBuilder.Entity<SupplyCategoriesXSupplyModel>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("supply_categories_x_supply");

                entity.Property(e => e.SupplyCategory).HasColumnName("supply_category");

                entity.Property(e => e.SupplyId).HasColumnName("supply_id");

                entity.HasOne(d => d.SupplyCategoryNavigation)
                    .WithMany()
                    .HasForeignKey(d => d.SupplyCategory)
                    .HasConstraintName("FK_supply_casuppl_628FA481");

                entity.HasOne(d => d.Supply)
                    .WithMany()
                    .HasForeignKey(d => d.SupplyId)
                    .HasConstraintName("FK_supply_casuppl_619B8048");
            });

            modelBuilder.Entity<SupplyCategoryModel>(entity =>
            {
                entity.ToTable("supply_categories");

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

            modelBuilder.Entity<SupplyDetailModel>(entity =>
            {
                entity.ToTable("supply_details");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.ActualQuantity).HasColumnName("actual_quantity");

                entity.Property(e => e.Batch)
                    .HasMaxLength(25)
                    .IsUnicode(false)
                    .HasColumnName("batch");

                entity.Property(e => e.Description)
                    .HasMaxLength(250)
                    .IsUnicode(false)
                    .HasColumnName("description");

                entity.Property(e => e.EntryDate)
                    .HasColumnType("datetime")
                    .HasColumnName("entry_date");

                entity.Property(e => e.ExpirationDate)
                    .HasColumnType("datetime")
                    .HasColumnName("expiration_date");

                entity.Property(e => e.InitialQuantity).HasColumnName("initial_quantity");

                entity.Property(e => e.ProviderId).HasColumnName("provider_id");

                entity.Property(e => e.StatedAt)
                    .HasColumnName("stated_at")
                    .HasDefaultValueSql("((1))");

                entity.Property(e => e.SupplyCost)
                    .HasColumnType("decimal(8, 2)")
                    .HasColumnName("supply_cost");

                entity.Property(e => e.SupplyId).HasColumnName("supply_id");

                entity.HasOne(d => d.Provider)
                    .WithMany(p => p.SupplyDetails)
                    .HasForeignKey(d => d.ProviderId)
                    .HasConstraintName("FK_supply_deprovi_66603565");

                entity.HasOne(d => d.Supply)
                    .WithMany(p => p.SupplyDetails)
                    .HasForeignKey(d => d.SupplyId)
                    .HasConstraintName("FK_supply_desuppl_656C112C");
            });

            modelBuilder.Entity<SupplyPictogramModel>(entity =>
            {
                entity.ToTable("supply_pictograms");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Code)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("code");

                entity.Property(e => e.Description)
                    .HasMaxLength(150)
                    .IsUnicode(false)
                    .HasColumnName("description");

                entity.Property(e => e.Name)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("name");

                entity.Property(e => e.PictogramFile).HasColumnName("pictogram_file");

                entity.Property(e => e.StatedAt)
                    .HasColumnName("stated_at")
                    .HasDefaultValueSql("((1))");
            });

            modelBuilder.Entity<SupplyXProductModel>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("supply_x_product");

                entity.Property(e => e.ProductId).HasColumnName("product_id");

                entity.Property(e => e.SupplyId).HasColumnName("supply_id");

                entity.HasOne(d => d.Product)
                    .WithMany()
                    .HasForeignKey(d => d.ProductId)
                    .HasConstraintName("FK_supply_x_produ_09A971A2");

                entity.HasOne(d => d.Supply)
                    .WithMany()
                    .HasForeignKey(d => d.SupplyId)
                    .HasConstraintName("FK_supply_x_suppl_0A9D95DB");
            });

            modelBuilder.Entity<SupplyXSupplyPictogramModel>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("supply_x_supply_pictograms");

                entity.Property(e => e.SupplyId).HasColumnName("supply_id");

                entity.Property(e => e.SupplyPictogramId).HasColumnName("supply_pictogram_id");

                entity.HasOne(d => d.Supply)
                    .WithMany()
                    .HasForeignKey(d => d.SupplyId)
                    .HasConstraintName("FK_supply_x_suppl_6C190EBB");

                entity.HasOne(d => d.SupplyPictogram)
                    .WithMany()
                    .HasForeignKey(d => d.SupplyPictogramId)
                    .HasConstraintName("FK_supply_x_suppl_6D0D32F4");

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

            modelBuilder.Entity<TypeServiceModel>(entity =>
            {
                entity.HasKey(e => e.Id)
                    .HasName("pk_TYPE_SERVICE");

                entity.ToTable("TYPE_SERVICE");

                entity.Property(e => e.Id).HasColumnName("id");

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
                entity.ToTable("type_service");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Name)
                    .HasMaxLength(100)
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
                    .HasConstraintName("FK_unit_measbase__6FE99F9F");
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

            modelBuilder.Entity<UnitMeasuresXSupplyModel>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("unit_measures_x_supply");

                entity.Property(e => e.SupplyId).HasColumnName("supply_id");

                entity.Property(e => e.UnitMeasureId).HasColumnName("unit_measure_id");

                entity.HasOne(d => d.Supply)
                    .WithMany()
                    .HasForeignKey(d => d.SupplyId)
                    .HasConstraintName("FK_unit_meassuppl_72C60C4A");

                entity.HasOne(d => d.UnitMeasure)
                    .WithMany()
                    .HasForeignKey(d => d.UnitMeasureId)
                    .HasConstraintName("FK_unit_measunit__73BA3083");

            });

            modelBuilder.Entity<UserModel>(entity =>
            {
                entity.ToTable("users");


                entity.HasIndex(e => e.Email, "UQ_users_AB6E616405D80F4C")
                    .IsUnique();

                entity.HasIndex(e => e.DocumentNumber, "UQ_users_C8FE0D8CE22CBB7C");

                entity.HasIndex(e => e.Email, "UQ_users_AB6E61649D4066DB")
                    .IsUnique();

                entity.HasIndex(e => e.DocumentNumber, "UQ_users_C8FE0D8CB1737385")

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

                    .HasConstraintName("FK_usersrole_id_46E78A0C");


                entity.HasOne(d => d.TypeDocument)
                    .WithMany(p => p.Users)
                    .HasForeignKey(d => d.TypeDocumentId)
                    .OnDelete(DeleteBehavior.ClientSetNull)

                    .HasConstraintName("FK_userstype_docu_45F365D3");

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

                    .HasConstraintName("FK_warehousewareh_5812160E");

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