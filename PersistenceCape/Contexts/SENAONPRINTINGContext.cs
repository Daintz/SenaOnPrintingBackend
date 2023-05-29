using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace DataCape.Models
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

        //public virtual DbSet<ApplicationPermissionModel> ApplicationPermissions { get; set; } = null!;
        public virtual DbSet<ClientModel> Clients { get; set; } = null!;
        //public virtual DbSet<FinishModel> Finishes { get; set; } = null!;
        //public virtual DbSet<FinishXQuotationClientDetailModel> FinishXQuotationClientDetails { get; set; } = null!;
        public virtual DbSet<GrammageCaliberModel> GrammageCalibers { get; set; } = null!;
        //public virtual DbSet<GrammageCaliberXQuotationClientDetailModel> GrammageCaliberXQuotationClientDetails { get; set; } = null!;
        //public virtual DbSet<ImpositionPlanchModel> ImpositionPlanches { get; set; } = null!;
        //public virtual DbSet<ImpositionPlanchXOrderProductionModel> ImpositionPlanchXOrderProductions { get; set; } = null!;
        //public virtual DbSet<LineatureModel> Lineatures { get; set; } = null!;
        //public virtual DbSet<LineatureXOrderProductionModel> LineatureXOrderProductions { get; set; } = null!;
        //public virtual DbSet<MachineModel> Machines { get; set; } = null!;
        //public virtual DbSet<MachinesXQuotationClientModel> MachinesXQuotationClients { get; set; } = null!;
        //public virtual DbSet<OrderProductionModel> OrderProductions { get; set; } = null!;
        public virtual DbSet<PaperCutModel> PaperCuts { get; set; } = null!;
        //public virtual DbSet<PermissionsByRoleModel> PermissionsByRoles { get; set; } = null!;
        //public virtual DbSet<ProductModel> Products { get; set; } = null!;
        //public virtual DbSet<ProviderModel> Providers { get; set; } = null!;
        //public virtual DbSet<QuotationClientModel> QuotationClients { get; set; } = null!;
        //public virtual DbSet<QuotationClientDetailModel> QuotationClientDetails { get; set; } = null!;
        //public virtual DbSet<QuotationProviderModel> QuotationProviders { get; set; } = null!;
        //public virtual DbSet<RoleModel> Roles { get; set; } = null!;
        public virtual DbSet<SubstrateModel> Substrates { get; set; } = null!;
        //public virtual DbSet<SubstrateXQuotationClientDetailModel> SubstrateXQuotationClientDetails { get; set; } = null!;
        //public virtual DbSet<SupplyModel> Supplies { get; set; } = null!;
        //public virtual DbSet<SupplyCategoriesXSupply> SupplyCategoriesXSupplies { get; set; } = null!;
        //public virtual DbSet<SupplyCategoryModel> SupplyCategories { get; set; } = null!;
        //public virtual DbSet<SupplyDetailModel> SupplyDetails { get; set; } = null!;
        //public virtual DbSet<SupplyPictogramModel> SupplyPictograms { get; set; } = null!;
        //public virtual DbSet<SupplyXProductModel> SupplyXProducts { get; set; } = null!;
        //public virtual DbSet<SupplyXSupplyPictogramModel> SupplyXSupplyPictograms { get; set; } = null!;
        //public virtual DbSet<TypeDocumentModel> TypeDocuments { get; set; } = null!;
        //public virtual DbSet<TypeServiceModel> TypeServices { get; set; } = null!;
        //public virtual DbSet<UnitMeasureModel> UnitMeasures { get; set; } = null!;
        //public virtual DbSet<UnitMeasuresXSupplyModel> UnitMeasuresXSupplies { get; set; } = null!;
        //public virtual DbSet<UserModel> Users { get; set; } = null!;
        //public virtual DbSet<WarehouseModel> Warehouses { get; set; } = null!;
        //public virtual DbSet<WarehouseTypeModel> WarehouseTypes { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("Server=DESKTOP-D1091LH\\SQLEXPRESS;Database=sena_on_printing;Trusted_Connection=True;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //modelBuilder.Entity<ApplicationPermissionModel>(entity =>
            //{
            //    entity.ToTable("application_permissions");

            //    entity.Property(e => e.Id).HasColumnName("id");

            //    entity.Property(e => e.Name)
            //        .HasMaxLength(50)
            //        .IsUnicode(false)
            //        .HasColumnName("name");
            //});

            modelBuilder.Entity<ClientModel>(entity =>
            {
                entity.ToTable("clients");

                entity.HasIndex(e => e.Email, "UQ__clients__AB6E6164160CA661")
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

            //modelBuilder.Entity<FinishModel>(entity =>
            //{
            //    entity.ToTable("finishes");

            //    entity.Property(e => e.Id).HasColumnName("id");

            //    entity.Property(e => e.Name)
            //        .HasMaxLength(100)
            //        .IsUnicode(false)
            //        .HasColumnName("name");

            //    entity.Property(e => e.StatedAt)
            //        .HasColumnName("stated_at")
            //        .HasDefaultValueSql("((1))");
            //});

            //modelBuilder.Entity<FinishXQuotationClientDetailModel>(entity =>
            //{
            //    entity.HasNoKey();

            //    entity.ToTable("finish_x_quotation_client_detail");

            //    entity.Property(e => e.FinishId).HasColumnName("finish_id");

            //    entity.Property(e => e.QuotationClientDetailId).HasColumnName("quotation_client_detail_id");

            //    entity.HasOne(d => d.Finish)
            //        .WithMany()
            //        .HasForeignKey(d => d.FinishId)
            //        .HasConstraintName("FK__finish_x___finis__31B762FC");

            //    entity.HasOne(d => d.QuotationClientDetail)
            //        .WithMany()
            //        .HasForeignKey(d => d.QuotationClientDetailId)
            //        .HasConstraintName("FK__finish_x___quota__30C33EC3");
            //});

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

            //modelBuilder.Entity<GrammageCaliberXQuotationClientDetailModel>(entity =>
            //{
            //    entity.HasNoKey();

            //    entity.ToTable("grammage_caliber_x_quotation_client_detail");

            //    entity.Property(e => e.GrammageCaliberId).HasColumnName("grammage_caliber_id");

            //    entity.Property(e => e.OrderProductionId).HasColumnName("order_production_id");

            //    entity.HasOne(d => d.GrammageCaliber)
            //        .WithMany()
            //        .HasForeignKey(d => d.GrammageCaliberId)
            //        .HasConstraintName("FK__grammage___gramm__3493CFA7");

            //    entity.HasOne(d => d.OrderProduction)
            //        .WithMany()
            //        .HasForeignKey(d => d.OrderProductionId)
            //        .HasConstraintName("FK__grammage___order__339FAB6E");
            //});

            //modelBuilder.Entity<ImpositionPlanchModel>(entity =>
            //{
            //    entity.ToTable("imposition_planch");

            //    entity.Property(e => e.Id).HasColumnName("id");

            //    entity.Property(e => e.Name)
            //        .HasMaxLength(100)
            //        .IsUnicode(false)
            //        .HasColumnName("name");

            //    entity.Property(e => e.Scheme).HasColumnName("scheme");

            //    entity.Property(e => e.StatedAt)
            //        .HasColumnName("stated_at")
            //        .HasDefaultValueSql("((1))");
            //});

            //modelBuilder.Entity<ImpositionPlanchXOrderProductionModel>(entity =>
            //{
            //    entity.HasNoKey();

            //    entity.ToTable("imposition_planch_x_order_production");

            //    entity.Property(e => e.ImpositionPlanchId).HasColumnName("imposition_planch_id");

            //    entity.Property(e => e.OrderProductionId).HasColumnName("order_production_id");

            //    entity.HasOne(d => d.ImpositionPlanch)
            //        .WithMany()
            //        .HasForeignKey(d => d.ImpositionPlanchId)
            //        .HasConstraintName("FK__impositio__impos__37703C52");

            //    entity.HasOne(d => d.OrderProduction)
            //        .WithMany()
            //        .HasForeignKey(d => d.OrderProductionId)
            //        .HasConstraintName("FK__impositio__order__367C1819");
            //});

            //modelBuilder.Entity<LineatureModel>(entity =>
            //{
            //    entity.ToTable("lineature");

            //    entity.Property(e => e.Id).HasColumnName("id");

            //    entity.Property(e => e.Lineature1)
            //        .HasMaxLength(100)
            //        .IsUnicode(false)
            //        .HasColumnName("lineature");

            //    entity.Property(e => e.StatedAt)
            //        .HasColumnName("stated_at")
            //        .HasDefaultValueSql("((1))");

            //    entity.Property(e => e.TypePoint)
            //        .HasMaxLength(150)
            //        .IsUnicode(false)
            //        .HasColumnName("type_point");
            //});

            //modelBuilder.Entity<LineatureXOrderProductionModel>(entity =>
            //{
            //    entity.HasNoKey();

            //    entity.ToTable("lineature_x_order_production");

            //    entity.Property(e => e.LineatureId).HasColumnName("lineature_id");

            //    entity.Property(e => e.OrderProductionId).HasColumnName("order_production_id");

            //    entity.HasOne(d => d.Lineature)
            //        .WithMany()
            //        .HasForeignKey(d => d.LineatureId)
            //        .HasConstraintName("FK__lineature__linea__3A4CA8FD");

            //    entity.HasOne(d => d.OrderProduction)
            //        .WithMany()
            //        .HasForeignKey(d => d.OrderProductionId)
            //        .HasConstraintName("FK__lineature__order__395884C4");
            //});

            //modelBuilder.Entity<MachineModel>(entity =>
            //{
            //    entity.ToTable("machines");

            //    entity.Property(e => e.Id).HasColumnName("id");

            //    entity.Property(e => e.CostByHour)
            //        .HasColumnType("decimal(18, 0)")
            //        .HasColumnName("cost_by_hour");

            //    entity.Property(e => e.CostByUnit)
            //        .HasColumnType("decimal(18, 0)")
            //        .HasColumnName("cost_by_unit");

            //    entity.Property(e => e.MaximumHeight)
            //        .HasColumnType("decimal(18, 0)")
            //        .HasColumnName("maximum_height");

            //    entity.Property(e => e.MaximumWidth)
            //        .HasColumnType("decimal(18, 0)")
            //        .HasColumnName("maximum_width");

            //    entity.Property(e => e.MinimumHeight)
            //        .HasColumnType("decimal(18, 0)")
            //        .HasColumnName("minimum_height");

            //    entity.Property(e => e.MinimumWidth)
            //        .HasColumnType("decimal(18, 0)")
            //        .HasColumnName("minimum_width");

            //    entity.Property(e => e.Name)
            //        .HasMaxLength(150)
            //        .IsUnicode(false)
            //        .HasColumnName("name");

            //    entity.Property(e => e.StatedAt)
            //        .HasColumnName("stated_at")
            //        .HasDefaultValueSql("((1))");
            //});

            //modelBuilder.Entity<MachinesXQuotationClientModel>(entity =>
            //{
            //    entity.HasNoKey();

            //    entity.ToTable("machines_x_quotation_client");

            //    entity.Property(e => e.MachineId).HasColumnName("machine_id");

            //    entity.Property(e => e.QuotationClientId).HasColumnName("quotation_client_id");

            //    entity.HasOne(d => d.Machine)
            //        .WithMany()
            //        .HasForeignKey(d => d.MachineId)
            //        .HasConstraintName("FK__machines___machi__3D2915A8");

            //    entity.HasOne(d => d.QuotationClient)
            //        .WithMany()
            //        .HasForeignKey(d => d.QuotationClientId)
            //        .HasConstraintName("FK__machines___quota__3C34F16F");
            //});

            //modelBuilder.Entity<OrderProductionModel>(entity =>
            //{
            //    entity.ToTable("order_production");

            //    entity.Property(e => e.Id).HasColumnName("id");

            //    entity.Property(e => e.ColorProfile)
            //        .HasMaxLength(255)
            //        .HasColumnName("color_profile");

            //    entity.Property(e => e.IdPaperCut).HasColumnName("id_paper_cut");

            //    entity.Property(e => e.Image).HasColumnName("image");

            //    entity.Property(e => e.Indented).HasColumnName("indented");

            //    entity.Property(e => e.InkCode)
            //        .HasMaxLength(100)
            //        .HasColumnName("ink_code");

            //    entity.Property(e => e.MaterialReception)
            //        .HasMaxLength(255)
            //        .IsUnicode(false)
            //        .HasColumnName("material_reception");

            //    entity.Property(e => e.Observations)
            //        .HasMaxLength(300)
            //        .HasColumnName("observations");

            //    entity.Property(e => e.OrderStatus).HasColumnName("order_status");

            //    entity.Property(e => e.Program)
            //        .HasMaxLength(50)
            //        .IsUnicode(false)
            //        .HasColumnName("program");

            //    entity.Property(e => e.ProgramVersion)
            //        .HasMaxLength(255)
            //        .HasColumnName("program_version");

            //    entity.Property(e => e.QuotationClientDetailId).HasColumnName("quotation_client_detail_id");

            //    entity.Property(e => e.SpecialInk)
            //        .HasMaxLength(255)
            //        .HasColumnName("special_ink");

            //    entity.Property(e => e.StatedAt).HasColumnName("stated_at");

            //    entity.Property(e => e.UserId).HasColumnName("user_id");

            //    entity.HasOne(d => d.IdPaperCutNavigation)
            //        .WithMany(p => p.OrderProductions)
            //        .HasForeignKey(d => d.IdPaperCut)
            //        .HasConstraintName("FK__order_pro__id_pa__2EDAF651");

            //    entity.HasOne(d => d.QuotationClientDetail)
            //        .WithMany(p => p.OrderProductions)
            //        .HasForeignKey(d => d.QuotationClientDetailId)
            //        .HasConstraintName("FK__order_pro__quota__2CF2ADDF");

            //    entity.HasOne(d => d.User)
            //        .WithMany(p => p.OrderProductions)
            //        .HasForeignKey(d => d.UserId)
            //        .HasConstraintName("FK__order_pro__user___2DE6D218");
            //});

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

            //modelBuilder.Entity<PermissionsByRoleModel>(entity =>
            //{
            //    entity.ToTable("permissions_by_role");

            //    entity.Property(e => e.Id).HasColumnName("id");

            //    entity.Property(e => e.PermissionId).HasColumnName("permission_id");

            //    entity.Property(e => e.RoleId).HasColumnName("role_id");

            //    entity.Property(e => e.StatedAt)
            //        .HasColumnName("stated_at")
            //        .HasDefaultValueSql("((1))");

            //    entity.HasOne(d => d.Permission)
            //        .WithMany(p => p.PermissionsByRoles)
            //        .HasForeignKey(d => d.PermissionId)
            //        .HasConstraintName("FK__permissio__permi__4E88ABD4");

            //    entity.HasOne(d => d.Role)
            //        .WithMany(p => p.PermissionsByRoles)
            //        .HasForeignKey(d => d.RoleId)
            //        .HasConstraintName("FK__permissio__role___4F7CD00D");
            //});

            //modelBuilder.Entity<ProductModel>(entity =>
            //{
            //    entity.ToTable("products");

            //    entity.Property(e => e.Id).HasColumnName("id");

            //    entity.Property(e => e.Characteristics)
            //        .HasColumnType("text")
            //        .HasColumnName("characteristics");

            //    entity.Property(e => e.Name)
            //        .HasMaxLength(100)
            //        .IsUnicode(false)
            //        .HasColumnName("name");

            //    entity.Property(e => e.StatedAt)
            //        .HasColumnName("stated_at")
            //        .HasDefaultValueSql("((1))");

            //    entity.Property(e => e.TypeProduct)
            //        .HasMaxLength(150)
            //        .IsUnicode(false)
            //        .HasColumnName("type_product");
            //});

            //modelBuilder.Entity<ProviderModel>(entity =>
            //{
            //    entity.ToTable("providers");

            //    entity.HasIndex(e => e.Email, "UQ__provider__AB6E616428C70F6A")
            //        .IsUnique();

            //    entity.Property(e => e.Id).HasColumnName("id");

            //    entity.Property(e => e.CompanyAddress)
            //        .HasMaxLength(150)
            //        .IsUnicode(false)
            //        .HasColumnName("company_address");

            //    entity.Property(e => e.Email)
            //        .HasMaxLength(110)
            //        .IsUnicode(false)
            //        .HasColumnName("email");

            //    entity.Property(e => e.NameCompany)
            //        .HasMaxLength(250)
            //        .IsUnicode(false)
            //        .HasColumnName("name_company");

            //    entity.Property(e => e.NitCompany)
            //        .HasMaxLength(15)
            //        .IsUnicode(false)
            //        .HasColumnName("nit_company");

            //    entity.Property(e => e.Phone)
            //        .HasMaxLength(10)
            //        .IsUnicode(false)
            //        .HasColumnName("phone");

            //    entity.Property(e => e.StatedAt)
            //        .HasColumnName("stated_at")
            //        .HasDefaultValueSql("((1))");
            //});

            //modelBuilder.Entity<QuotationClientModel>(entity =>
            //{
            //    entity.ToTable("quotation_clients");

            //    entity.Property(e => e.Id).HasColumnName("id");

            //    entity.Property(e => e.ClientId).HasColumnName("client_id");

            //    entity.Property(e => e.DeliverDate)
            //        .HasColumnType("date")
            //        .HasColumnName("deliver_date");

            //    entity.Property(e => e.OrderDate)
            //        .HasColumnType("date")
            //        .HasColumnName("order_date");

            //    entity.Property(e => e.QuotationStatus).HasColumnName("quotation_status");

            //    entity.Property(e => e.StatedAt)
            //        .HasColumnName("stated_at")
            //        .HasDefaultValueSql("((1))");

            //    entity.Property(e => e.TypeServiceId).HasColumnName("type_service_id");

            //    entity.Property(e => e.UserId).HasColumnName("user_id");

            //    entity.HasOne(d => d.Client)
            //        .WithMany(p => p.QuotationClients)
            //        .HasForeignKey(d => d.ClientId)
            //        .HasConstraintName("FK__quotation__clien__208CD6FA");

            //    entity.HasOne(d => d.TypeService)
            //        .WithMany(p => p.QuotationClients)
            //        .HasForeignKey(d => d.TypeServiceId)
            //        .HasConstraintName("FK__quotation__type___2180FB33");

            //    entity.HasOne(d => d.User)
            //        .WithMany(p => p.QuotationClients)
            //        .HasForeignKey(d => d.UserId)
            //        .HasConstraintName("FK__quotation__user___1F98B2C1");
            //});

            //modelBuilder.Entity<QuotationClientDetailModel>(entity =>
            //{
            //    entity.ToTable("quotation_client_details");

            //    entity.Property(e => e.Id).HasColumnName("id");

            //    entity.Property(e => e.FullValue).HasColumnName("full_value");

            //    entity.Property(e => e.InkQuantity).HasColumnName("ink_quantity");

            //    entity.Property(e => e.NumberOfPages).HasColumnName("number_of_pages");

            //    entity.Property(e => e.ProductHeight).HasColumnName("product_height");

            //    entity.Property(e => e.ProductId).HasColumnName("product_id");

            //    entity.Property(e => e.ProductQuantity).HasColumnName("product_quantity");

            //    entity.Property(e => e.ProductWidth).HasColumnName("product_width");

            //    entity.Property(e => e.QuotationClientId).HasColumnName("quotation_client_id");

            //    entity.Property(e => e.StatedAt)
            //        .HasColumnName("stated_at")
            //        .HasDefaultValueSql("((1))");

            //    entity.Property(e => e.TechnicalSpecifications)
            //        .HasMaxLength(255)
            //        .IsUnicode(false)
            //        .HasColumnName("technical_specifications");

            //    entity.Property(e => e.UnitValue).HasColumnName("unit_value");

            //    entity.HasOne(d => d.Product)
            //        .WithMany(p => p.QuotationClientDetails)
            //        .HasForeignKey(d => d.ProductId)
            //        .HasConstraintName("FK__quotation__produ__2645B050");

            //    entity.HasOne(d => d.QuotationClient)
            //        .WithMany(p => p.QuotationClientDetails)
            //        .HasForeignKey(d => d.QuotationClientId)
            //        .HasConstraintName("FK__quotation__quota__25518C17");
            //});

            //modelBuilder.Entity<QuotationProviderModel>(entity =>
            //{
            //    entity.ToTable("quotation_providers");

            //    entity.Property(e => e.Id).HasColumnName("id");

            //    entity.Property(e => e.FullValue).HasColumnName("full_value");

            //    entity.Property(e => e.ProviderId).HasColumnName("provider_id");

            //    entity.Property(e => e.QuotationDate)
            //        .HasColumnType("date")
            //        .HasColumnName("quotation_date");

            //    entity.Property(e => e.QuotationFile).HasColumnName("quotation_file");

            //    entity.Property(e => e.StatedAt)
            //        .HasColumnName("stated_at")
            //        .HasDefaultValueSql("((1))");

            //    entity.HasOne(d => d.Provider)
            //        .WithMany(p => p.QuotationProviders)
            //        .HasForeignKey(d => d.ProviderId)
            //        .HasConstraintName("FK__quotation__provi__40058253");
            //});

            //modelBuilder.Entity<RoleModel>(entity =>
            //{
            //    entity.ToTable("roles");

            //    entity.Property(e => e.Id).HasColumnName("id");

            //    entity.Property(e => e.Description)
            //        .HasMaxLength(150)
            //        .IsUnicode(false)
            //        .HasColumnName("description");

            //    entity.Property(e => e.Name)
            //        .HasMaxLength(80)
            //        .IsUnicode(false)
            //        .HasColumnName("name");

            //    entity.Property(e => e.StatedAt)
            //        .HasColumnName("stated_at")
            //        .HasDefaultValueSql("((1))");
            //});

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

            //modelBuilder.Entity<SubstrateXQuotationClientDetailModel>(entity =>
            //{
            //    entity.HasNoKey();

            //    entity.ToTable("substrate_x_quotation_client_detail");

            //    entity.Property(e => e.QuotationClientDetailId).HasColumnName("quotation_client_detail_id");

            //    entity.Property(e => e.SubstrateId).HasColumnName("substrate_id");

            //    entity.HasOne(d => d.QuotationClientDetail)
            //        .WithMany()
            //        .HasForeignKey(d => d.QuotationClientDetailId)
            //        .HasConstraintName("FK__substrate__quota__42E1EEFE");

            //    entity.HasOne(d => d.Substrate)
            //        .WithMany()
            //        .HasForeignKey(d => d.SubstrateId)
            //        .HasConstraintName("FK__substrate__subst__43D61337");
            //});

            //modelBuilder.Entity<SupplyModel>(entity =>
            //{
            //    entity.ToTable("supplies");

            //    entity.Property(e => e.Id).HasColumnName("id");

            //    entity.Property(e => e.Advices)
            //        .HasColumnType("text")
            //        .HasColumnName("advices");

            //    entity.Property(e => e.AverageCost)
            //        .HasColumnType("decimal(8, 2)")
            //        .HasColumnName("average_cost");

            //    entity.Property(e => e.DangerIndicators)
            //        .HasColumnType("text")
            //        .HasColumnName("danger_indicators");

            //    entity.Property(e => e.Name)
            //        .HasMaxLength(200)
            //        .IsUnicode(false)
            //        .HasColumnName("name");

            //    entity.Property(e => e.Quantity).HasColumnName("quantity");

            //    entity.Property(e => e.SortingWord).HasColumnName("sorting_word");

            //    entity.Property(e => e.StatedAt)
            //        .HasColumnName("stated_at")
            //        .HasDefaultValueSql("((1))");

            //    entity.Property(e => e.SupplyType).HasColumnName("supply_type");

            //    entity.Property(e => e.UseInstructions)
            //        .HasColumnType("text")
            //        .HasColumnName("use_instructions");

            //    entity.Property(e => e.WarehouseId).HasColumnName("warehouse_id");

            //    entity.HasOne(d => d.Warehouse)
            //        .WithMany(p => p.Supplies)
            //        .HasForeignKey(d => d.WarehouseId)
            //        .HasConstraintName("FK__supplies__wareho__6E01572D");
            //});

            //modelBuilder.Entity<SupplyCategoriesXSupply>(entity =>
            //{
            //    entity.HasNoKey();

            //    entity.ToTable("supply_categories_x_supply");

            //    entity.Property(e => e.SupplyCategory).HasColumnName("supply_category");

            //    entity.Property(e => e.SupplyId).HasColumnName("supply_id");

            //    entity.HasOne(d => d.SupplyCategoryNavigation)
            //        .WithMany()
            //        .HasForeignKey(d => d.SupplyCategory)
            //        .HasConstraintName("FK__supply_ca__suppl__74AE54BC");

            //    entity.HasOne(d => d.Supply)
            //        .WithMany()
            //        .HasForeignKey(d => d.SupplyId)
            //        .HasConstraintName("FK__supply_ca__suppl__73BA3083");
            //});

            //modelBuilder.Entity<SupplyCategoryModel>(entity =>
            //{
            //    entity.ToTable("supply_categories");

            //    entity.Property(e => e.Id).HasColumnName("id");

            //    entity.Property(e => e.Description)
            //        .HasMaxLength(150)
            //        .IsUnicode(false)
            //        .HasColumnName("description");

            //    entity.Property(e => e.Name)
            //        .HasMaxLength(100)
            //        .IsUnicode(false)
            //        .HasColumnName("name");

            //    entity.Property(e => e.StatedAt)
            //        .HasColumnName("stated_at")
            //        .HasDefaultValueSql("((1))");
            //});

            //modelBuilder.Entity<SupplyDetailModel>(entity =>
            //{
            //    entity.ToTable("supply_details");

            //    entity.Property(e => e.Id).HasColumnName("id");

            //    entity.Property(e => e.ActualQuantity).HasColumnName("actual_quantity");

            //    entity.Property(e => e.Batch)
            //        .HasMaxLength(25)
            //        .IsUnicode(false)
            //        .HasColumnName("batch");

            //    entity.Property(e => e.Description)
            //        .HasMaxLength(250)
            //        .IsUnicode(false)
            //        .HasColumnName("description");

            //    entity.Property(e => e.EntryDate)
            //        .HasColumnType("datetime")
            //        .HasColumnName("entry_date");

            //    entity.Property(e => e.ExpirationDate)
            //        .HasColumnType("datetime")
            //        .HasColumnName("expiration_date");

            //    entity.Property(e => e.InitialQuantity).HasColumnName("initial_quantity");

            //    entity.Property(e => e.ProviderId).HasColumnName("provider_id");

            //    entity.Property(e => e.StatedAt)
            //        .HasColumnName("stated_at")
            //        .HasDefaultValueSql("((1))");

            //    entity.Property(e => e.SupplyCost)
            //        .HasColumnType("decimal(8, 2)")
            //        .HasColumnName("supply_cost");

            //    entity.Property(e => e.SupplyId).HasColumnName("supply_id");

            //    entity.HasOne(d => d.Provider)
            //        .WithMany(p => p.SupplyDetails)
            //        .HasForeignKey(d => d.ProviderId)
            //        .HasConstraintName("FK__supply_de__provi__787EE5A0");

            //    entity.HasOne(d => d.Supply)
            //        .WithMany(p => p.SupplyDetails)
            //        .HasForeignKey(d => d.SupplyId)
            //        .HasConstraintName("FK__supply_de__suppl__778AC167");
            //});

            //modelBuilder.Entity<SupplyPictogramModel>(entity =>
            //{
            //    entity.ToTable("supply_pictograms");

            //    entity.Property(e => e.Id).HasColumnName("id");

            //    entity.Property(e => e.Description)
            //        .HasMaxLength(150)
            //        .IsUnicode(false)
            //        .HasColumnName("description");

            //    entity.Property(e => e.Name)
            //        .HasMaxLength(100)
            //        .IsUnicode(false)
            //        .HasColumnName("name");

            //    entity.Property(e => e.PictogramFile).HasColumnName("pictogram_file");

            //    entity.Property(e => e.StatedAt)
            //        .HasColumnName("stated_at")
            //        .HasDefaultValueSql("((1))");
            //});

            //modelBuilder.Entity<SupplyXProductModel>(entity =>
            //{
            //    entity.HasNoKey();

            //    entity.ToTable("supply_x_product");

            //    entity.Property(e => e.ProductId).HasColumnName("product_id");

            //    entity.Property(e => e.SupplyId).HasColumnName("supply_id");

            //    entity.HasOne(d => d.Product)
            //        .WithMany()
            //        .HasForeignKey(d => d.ProductId)
            //        .HasConstraintName("FK__supply_x___produ__1BC821DD");

            //    entity.HasOne(d => d.Supply)
            //        .WithMany()
            //        .HasForeignKey(d => d.SupplyId)
            //        .HasConstraintName("FK__supply_x___suppl__1CBC4616");
            //});

            //modelBuilder.Entity<SupplyXSupplyPictogramModel>(entity =>
            //{
            //    entity.HasNoKey();

            //    entity.ToTable("supply_x_supply_pictograms");

            //    entity.Property(e => e.SupplyId).HasColumnName("supply_id");

            //    entity.Property(e => e.SupplyPictogramId).HasColumnName("supply_pictogram_id");

            //    entity.HasOne(d => d.Supply)
            //        .WithMany()
            //        .HasForeignKey(d => d.SupplyId)
            //        .HasConstraintName("FK__supply_x___suppl__7E37BEF6");

            //    entity.HasOne(d => d.SupplyPictogram)
            //        .WithMany()
            //        .HasForeignKey(d => d.SupplyPictogramId)
            //        .HasConstraintName("FK__supply_x___suppl__7F2BE32F");
            //});

            //modelBuilder.Entity<TypeDocumentModel>(entity =>
            //{
            //    entity.ToTable("type_documents");

            //    entity.Property(e => e.Id).HasColumnName("id");

            //    entity.Property(e => e.Abbreviation)
            //        .HasMaxLength(5)
            //        .IsUnicode(false)
            //        .HasColumnName("abbreviation");

            //    entity.Property(e => e.Name)
            //        .HasMaxLength(80)
            //        .IsUnicode(false)
            //        .HasColumnName("name");

            //    entity.Property(e => e.StatedAt)
            //        .HasColumnName("stated_at")
            //        .HasDefaultValueSql("((1))");
            //});

            //modelBuilder.Entity<TypeServiceModel>(entity =>
            //{
            //    entity.ToTable("type_service");

            //    entity.Property(e => e.Id).HasColumnName("id");

            //    entity.Property(e => e.Name)
            //        .HasMaxLength(100)
            //        .IsUnicode(false)
            //        .HasColumnName("name");

            //    entity.Property(e => e.StatedAt)
            //        .HasColumnName("stated_at")
            //        .HasDefaultValueSql("((1))");
            //});

            //modelBuilder.Entity<UnitMeasureModel>(entity =>
            //{
            //    entity.ToTable("unit_measures");

            //    entity.Property(e => e.Id).HasColumnName("id");

            //    entity.Property(e => e.Abbreviation)
            //        .HasMaxLength(10)
            //        .IsUnicode(false)
            //        .HasColumnName("abbreviation");

            //    entity.Property(e => e.BaseId).HasColumnName("base_id");

            //    entity.Property(e => e.ConversionFactor)
            //        .HasColumnType("decimal(8, 2)")
            //        .HasColumnName("conversion_factor");

            //    entity.Property(e => e.Name)
            //        .HasMaxLength(100)
            //        .IsUnicode(false)
            //        .HasColumnName("name");

            //    entity.Property(e => e.StatedAt)
            //        .HasColumnName("stated_at")
            //        .HasDefaultValueSql("((1))");

            //    entity.Property(e => e.Type).HasColumnName("type");

            //    entity.HasOne(d => d.Base)
            //        .WithMany(p => p.InverseBase)
            //        .HasForeignKey(d => d.BaseId)
            //        .HasConstraintName("FK__unit_meas__base___02084FDA");
            //});

            //modelBuilder.Entity<UnitMeasuresXSupplyModel>(entity =>
            //{
            //    entity.HasNoKey();

            //    entity.ToTable("unit_measures_x_supply");

            //    entity.Property(e => e.SupplyId).HasColumnName("supply_id");

            //    entity.Property(e => e.UnitMeasureId).HasColumnName("unit_measure_id");

            //    entity.HasOne(d => d.Supply)
            //        .WithMany()
            //        .HasForeignKey(d => d.SupplyId)
            //        .HasConstraintName("FK__unit_meas__suppl__04E4BC85");

            //    entity.HasOne(d => d.UnitMeasure)
            //        .WithMany()
            //        .HasForeignKey(d => d.UnitMeasureId)
            //        .HasConstraintName("FK__unit_meas__unit___05D8E0BE");
            //});

            //modelBuilder.Entity<UserModel>(entity =>
            //{
            //    entity.ToTable("users");

            //    entity.HasIndex(e => e.Email, "UQ__users__AB6E6164748C84C7")
            //        .IsUnique();

            //    entity.HasIndex(e => e.DocumentNumber, "UQ__users__C8FE0D8C8795002A")
            //        .IsUnique();

            //    entity.Property(e => e.Id).HasColumnName("id");

            //    entity.Property(e => e.Address)
            //        .HasMaxLength(150)
            //        .IsUnicode(false)
            //        .HasColumnName("address");

            //    entity.Property(e => e.DocumentNumber)
            //        .HasMaxLength(15)
            //        .IsUnicode(false)
            //        .HasColumnName("document_number");

            //    entity.Property(e => e.Email)
            //        .HasMaxLength(110)
            //        .IsUnicode(false)
            //        .HasColumnName("email");

            //    entity.Property(e => e.Names)
            //        .HasMaxLength(90)
            //        .IsUnicode(false)
            //        .HasColumnName("names");

            //    entity.Property(e => e.PasswordDigest)
            //        .HasMaxLength(250)
            //        .IsUnicode(false)
            //        .HasColumnName("password_digest");

            //    entity.Property(e => e.Phone)
            //        .HasMaxLength(10)
            //        .IsUnicode(false)
            //        .HasColumnName("phone");

            //    entity.Property(e => e.RoleId).HasColumnName("role_id");

            //    entity.Property(e => e.StatedAt)
            //        .HasColumnName("stated_at")
            //        .HasDefaultValueSql("((1))");

            //    entity.Property(e => e.Surnames)
            //        .HasMaxLength(90)
            //        .IsUnicode(false)
            //        .HasColumnName("surnames");

            //    entity.Property(e => e.TypeDocumentId).HasColumnName("type_document_id");

            //    entity.HasOne(d => d.Role)
            //        .WithMany(p => p.Users)
            //        .HasForeignKey(d => d.RoleId)
            //        .OnDelete(DeleteBehavior.ClientSetNull)
            //        .HasConstraintName("FK__users__role_id__59063A47");

            //    entity.HasOne(d => d.TypeDocument)
            //        .WithMany(p => p.Users)
            //        .HasForeignKey(d => d.TypeDocumentId)
            //        .OnDelete(DeleteBehavior.ClientSetNull)
            //        .HasConstraintName("FK__users__type_docu__5812160E");
            //});

            //modelBuilder.Entity<WarehouseModel>(entity =>
            //{
            //    entity.ToTable("warehouse");

            //    entity.Property(e => e.Id).HasColumnName("id");

            //    entity.Property(e => e.Name)
            //        .HasMaxLength(100)
            //        .IsUnicode(false)
            //        .HasColumnName("name");

            //    entity.Property(e => e.StatedAt)
            //        .HasColumnName("stated_at")
            //        .HasDefaultValueSql("((1))");

            //    entity.Property(e => e.Ubication)
            //        .HasMaxLength(150)
            //        .IsUnicode(false)
            //        .HasColumnName("ubication");

            //    entity.Property(e => e.WarehouseTypeId).HasColumnName("warehouse_type_id");

            //    entity.HasOne(d => d.WarehouseType)
            //        .WithMany(p => p.Warehouses)
            //        .HasForeignKey(d => d.WarehouseTypeId)
            //        .HasConstraintName("FK__warehouse__wareh__6A30C649");
            //});

            //modelBuilder.Entity<WarehouseTypeModel>(entity =>
            //{
            //    entity.ToTable("warehouse_type");

            //    entity.Property(e => e.Id).HasColumnName("id");

            //    entity.Property(e => e.Description)
            //        .HasMaxLength(150)
            //        .IsUnicode(false)
            //        .HasColumnName("description");

            //    entity.Property(e => e.Name)
            //        .HasMaxLength(100)
            //        .IsUnicode(false)
            //        .HasColumnName("name");

            //    entity.Property(e => e.StatedAt)
            //        .HasColumnName("stated_at")
            //        .HasDefaultValueSql("((1))");
            //});

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
