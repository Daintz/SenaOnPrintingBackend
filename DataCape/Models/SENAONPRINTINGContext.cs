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

        public virtual DbSet<ApplicationPermissionModel> ApplicationPermissions { get; set; } = null!;
        public virtual DbSet<ClientModel> Clients { get; set; } = null!;
        public virtual DbSet<FinishModel> Finishes { get; set; } = null!;
        public virtual DbSet<FinishXProductModel> FinishXQuotationClientDetails { get; set; } = null!;
        public virtual DbSet<ImpositionPlanchModel> ImpositionPlanches { get; set; } = null!;
        public virtual DbSet<MachineModel> Machines { get; set; } = null!;
        public virtual DbSet<OrderProductionModel> OrderProductions { get; set; } = null!;
        public virtual DbSet<PaperCutModel> PaperCuts { get; set; } = null!;
        public virtual DbSet<PermissionsByRoleModel> PermissionsByRoles { get; set; } = null!;
        public virtual DbSet<ProductModel> Products { get; set; } = null!;
        public virtual DbSet<ProviderModel> Providers { get; set; } = null!;
        public virtual DbSet<QuotationClientModel> QuotationClients { get; set; } = null!;
        public virtual DbSet<QuotationClientDetailModel> QuotationClientDetails { get; set; } = null!;
        public virtual DbSet<QuotationProviderModel> QuotationProviders { get; set; } = null!;
        public virtual DbSet<RoleModel> Roles { get; set; } = null!;
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

                entity.HasIndex(e => e.Email, "UQ__clients__AB6E61642DD007FB")
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

                entity.Property(e => e.Cost)
                    .HasColumnType("decimal(18, 0)")
                    .HasColumnName("cost");

                entity.Property(e => e.Name)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("name");

                entity.Property(e => e.StatedAt)
                    .HasColumnName("stated_at")
                    .HasDefaultValueSql("((1))");
            });

            modelBuilder.Entity<FinishXProductModel>(entity =>
            {

                entity.ToTable("finish_x_product");

                entity.Property(e => e.FinishId).HasColumnName("finish_id");

                entity.Property(e => e.ProductId).HasColumnName("product_id");

                entity.HasOne(d => d.Finish)
                    .WithMany()
                    .HasForeignKey(d => d.FinishId)
                    .HasConstraintName("FK__finish_x___finis__0D7A0286");

                entity.HasOne(d => d.Product)
                    .WithMany()
                    .HasForeignKey(d => d.ProductId)
                    .HasConstraintName("FK__finish_x___produ__0E6E26BF");
                entity.HasKey(e => new { e.FinishId, e.ProductId});
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

            modelBuilder.Entity<OrderProductionModel>(entity =>
            {
                entity.ToTable("order_production");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.ColorProfile)
                    .HasMaxLength(255)
                    .HasColumnName("color_profile");

                entity.Property(e => e.Image)
                    .HasMaxLength(250)
                    .IsUnicode(false)
                    .HasColumnName("image");

                entity.Property(e => e.ImpositionPlanchId).HasColumnName("imposition_planch_id");

                entity.Property(e => e.Indented).HasColumnName("indented");

                entity.Property(e => e.Lineature)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("lineature");

                entity.Property(e => e.MachineId).HasColumnName("machine_id");

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

                entity.Property(e => e.QuotationClientDetailId).HasColumnName("quotation_client_detail_id");

                entity.Property(e => e.Scheme)
                    .HasMaxLength(250)
                    .IsUnicode(false)
                    .HasColumnName("scheme");

                entity.Property(e => e.StatedAt).HasColumnName("stated_at");

                entity.Property(e => e.TypePoint)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("type_point");

                entity.Property(e => e.UserId).HasColumnName("user_id");

                entity.HasOne(d => d.ImpositionPlanch)
                    .WithMany(p => p.OrderProductions)
                    .HasForeignKey(d => d.ImpositionPlanchId)
                    .HasConstraintName("FK__order_pro__impos__10566F31");

                entity.HasOne(d => d.Machine)
                    .WithMany(p => p.OrderProductions)
                    .HasForeignKey(d => d.MachineId)
                    .HasConstraintName("FK__order_pro__machi__0F624AF8");

                entity.HasOne(d => d.QuotationClientDetail)
                    .WithMany(p => p.OrderProductions)
                    .HasForeignKey(d => d.QuotationClientDetailId)
                    .HasConstraintName("FK__order_pro__quota__114A936A");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.OrderProductions)
                    .HasForeignKey(d => d.UserId)
                    .HasConstraintName("FK__order_pro__user___123EB7A3");
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


                entity.Property(e => e.PermissionId).HasColumnName("permission_id");

                entity.Property(e => e.RoleId).HasColumnName("role_id");

                entity.HasOne(d => d.Permission)
                    .WithMany(p => p.PermissionsByRoles)
                    .HasForeignKey(d => d.PermissionId)
                    .HasConstraintName("FK__permissio__permi__2CF2ADDF");

                entity.HasOne(d => d.Role)
                    .WithMany(p => p.PermissionsByRoles)
                    .HasForeignKey(d => d.RoleId)
                    .HasConstraintName("FK__permissio__role___2DE6D218");

                entity.HasKey(e => new { e.RoleId, e.PermissionId });
            });

            modelBuilder.Entity<ProductModel>(entity =>
            {
                entity.ToTable("products");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.BackCover).HasColumnName("back_cover");

                entity.Property(e => e.BackCoverCode)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("back_cover_code");

                entity.Property(e => e.BackCoverInks).HasColumnName("back_cover_inks");

                entity.Property(e => e.BackCoverNumberInks)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("back_cover_number_inks");

                entity.Property(e => e.BackCoverPantone)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("back_cover_pantone");

                entity.Property(e => e.Cover)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("cover");

                entity.Property(e => e.Bindings)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("bindings");

                entity.Property(e => e.Cost)
                    .HasColumnType("decimal(18, 0)")
                    .HasColumnName("cost");

                entity.Property(e => e.Dimension)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("dimension");

                entity.Property(e => e.FrontPage).HasColumnName("front_page");

                entity.Property(e => e.FrontPageCode)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("front_page_code");

                entity.Property(e => e.FrontPageInks).HasColumnName("Front_page_inks");

                entity.Property(e => e.FrontPageNumberInks)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("front_page_number_inks");

                entity.Property(e => e.FrontPagePantone)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("front_page_pantone");

                entity.Property(e => e.Inside).HasColumnName("inside");

                entity.Property(e => e.InsideCode)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("inside_code");

                entity.Property(e => e.InsideInks).HasColumnName("inside_inks");

                entity.Property(e => e.InsideNumberInks)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("inside_number_inks");

                entity.Property(e => e.InsidePantone)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("inside_pantone");

                entity.Property(e => e.Name)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("name");

                entity.Property(e => e.NumberPages).HasColumnName("number_pages");

                entity.Property(e => e.Observations)
                    .HasColumnType("text")
                    .HasColumnName("observations");

                entity.Property(e => e.PaperCutId).HasColumnName("paper_cut_id");

                entity.Property(e => e.Size)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("size");

                entity.Property(e => e.StatedAt)
                    .HasColumnName("stated_at")
                    .HasDefaultValueSql("((1))");

                entity.Property(e => e.Substratum)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("substratum");

                entity.Property(e => e.SubstratumFrontPage)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("substratum_front_page");

                entity.Property(e => e.SubstratumInside)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("substratum_inside");

                entity.Property(e => e.TypeProduct)
                    .HasMaxLength(150)
                    .IsUnicode(false)
                    .HasColumnName("type_product");

                entity.HasOne(d => d.PaperCut)
                    .WithMany(p => p.Products)
                    .HasForeignKey(d => d.PaperCutId)
                    .HasConstraintName("FK_productspaper__6754599E");
            });

            modelBuilder.Entity<ProviderModel>(entity =>
            {
                entity.ToTable("providers");

                entity.HasIndex(e => e.Email, "UQ__provider__AB6E6164C6F2EE76")
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

                entity.Property(e => e.FullValue).HasColumnName("full_value");

                entity.Property(e => e.StatedAt)
                    .HasColumnName("stated_at")
                    .HasDefaultValueSql("((1))");
            

                entity.Property(e => e.UserId).HasColumnName("user_id");

                entity.HasOne(d => d.Client)
                    .WithMany(p => p.QuotationClients)
                    .HasForeignKey(d => d.ClientId)
                    .HasConstraintName("FK__quotation__clien__30C33EC3");
           

                entity.HasOne(d => d.User)
                    .WithMany(p => p.QuotationClients)
                    .HasForeignKey(d => d.UserId)
                    .HasConstraintName("FK__quotation__user___32AB8735");
            });

            modelBuilder.Entity<QuotationClientDetailModel>(entity =>
            {
                entity.ToTable("quotation_client_details");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.ProductId).HasColumnName("product_id");
                entity.Property(e => e.TypeServiceId).HasColumnName("type_service_id");

                entity.Property(e => e.Cost).HasColumnName("cost");
                entity.Property(e => e.Quantity).HasColumnName("quantity");

                entity.Property(e => e.QuotationClientId).HasColumnName("quotation_client_id");

                entity.Property(e => e.StatedAt)
                    .HasColumnName("stated_at")
                    .HasDefaultValueSql("((1))");

          

                entity.HasOne(d => d.QuotationClient)
                    .WithMany(p => p.QuotationClientDetails)
                    .HasForeignKey(d => d.QuotationClientId)
                    .HasConstraintName("FK__quotation__quota__2FCF1A8A");

                entity.HasOne(d => d.Product)
                    .WithMany(p => p.QuotationClientDetails)
                    .HasForeignKey(d => d.ProductId);

                entity.HasOne(d => d.TypeServiceModel)
                    .WithMany(p => p.QuotationClientDetails)
                    .HasForeignKey(d => d.TypeServiceId);
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

                entity.Property(e => e.QuotationFile)
                    .HasMaxLength(300)
                    .IsUnicode(false)
                    .HasColumnName("quotation_file");

                entity.Property(e => e.StatedAt)
                    .HasColumnName("stated_at")
                    .HasDefaultValueSql("((1))");

                entity.HasOne(d => d.Provider)
                    .WithMany(p => p.QuotationProviders)
                    .HasForeignKey(d => d.ProviderId)
                    .HasConstraintName("FK__quotation__provi__339FAB6E");
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

            modelBuilder.Entity<SupplyModel>(entity =>
            {
                entity.ToTable("supplies");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Name)
                .HasMaxLength(200)
                .IsUnicode(false)
                .HasColumnName("name");

                entity.Property(e => e.DangerIndicators)
                .HasColumnType("text")
                .HasColumnName("danger_indicators");

                entity.Property(e => e.UseInstructions)
              .HasColumnType("text")
              .HasColumnName("use_instructions");

                entity.Property(e => e.Advices)
                    .HasColumnType("text")
                    .HasColumnName("advices");



                entity.Property(e => e.SupplyType).HasColumnName("supply_type");


                entity.Property(e => e.SortingWord).HasColumnName("sorting_word");

                entity.Property(e => e.Quantity).HasColumnName("quantity");


                entity.Property(e => e.AverageCost)
                    .HasColumnType("decimal(8, 2)")
                    .HasColumnName("average_cost");


                entity.Property(e => e.StatedAt)
                    .HasColumnName("stated_at")
                    .HasDefaultValueSql("((1))");

             
            });

            modelBuilder.Entity<SupplyCategoriesXSupplyModel>(entity =>
            {

                entity.HasKey(e => new { e.SupplyId, e.SupplyCategoryId });
                entity.ToTable("supply_categories_x_supply");

                entity.Property(e => e.SupplyCategoryId).HasColumnName("supply_category_id");

                entity.Property(e => e.SupplyId).HasColumnName("supply_id");

                entity.HasOne(d => d.SupplyCategoryNavigation)
                    .WithMany(d => d.SupplyCategoriesXSupply)
                    .HasForeignKey(d => d.SupplyCategoryId)
                    .HasConstraintName("FK__supply_ca__suppl__3B40CD36");

                entity.HasOne(d => d.Supply)
                    .WithMany(d => d.SupplyCategoriesXSupply)
                    .HasForeignKey(d => d.SupplyId)
                    .HasConstraintName("FK__supply_ca__suppl__3A4CA8FD");

              
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
                //entity.Property(e => e.Batch).HasColumnName("batch");


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


                entity.Property(e => e.ProviderId).HasColumnName("provider_id");

                entity.Property(e => e.StatedAt)
                    .HasColumnName("stated_at")
                    .HasDefaultValueSql("((1))");

                entity.Property(e => e.SupplyCost)
                    .HasColumnType("decimal(8, 2)")
                    .HasColumnName("supply_cost");

                entity.Property(e => e.SupplyId).HasColumnName("supply_id");

                entity.Property(e => e.WarehouseId).HasColumnName("warehouse_id");

                entity.HasOne(d => d.Provider)
                    .WithMany(p => p.SupplyDetails)
                    .HasForeignKey(d => d.ProviderId)
                    .HasConstraintName("provider_idContraint");

                entity.HasOne(d => d.Supply)
                    .WithMany(p => p.SupplyDetails)
                    .HasForeignKey(d => d.SupplyId)
                    .HasConstraintName("supply_idContraint");

                entity.HasOne(d => d.Warehouse)
                    .WithMany(p => p.SupplyDetails)
                    .HasForeignKey(d => d.WarehouseId)
                    .HasConstraintName("warehouse_id");
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

                entity.Property(e => e.PictogramFile)
                    .HasMaxLength(300)
                    .IsUnicode(false)
                    .HasColumnName("pictogram_file");

                entity.Property(e => e.StatedAt)
                    .HasColumnName("stated_at")
                    .HasDefaultValueSql("((1))");
            });

            modelBuilder.Entity<SupplyXProductModel>(entity =>
            {
                //entity.HasNoKey();
                entity.HasKey(e => new { e.SupplyId, e.ProductId});

                entity.ToTable("supply_x_product");

                entity.Property(e => e.ProductId).HasColumnName("product_id");

                entity.Property(e => e.SupplyId).HasColumnName("supply_id");

                entity.HasOne(d => d.Product)
                    .WithMany(d => d.Supplies)
                    .HasForeignKey(d => d.ProductId)
                    .HasConstraintName("FK__supply_x___produ__3F115E1A");

                entity.HasOne(d => d.Supply)
                    .WithMany(d => d.Products)
                    .HasForeignKey(d => d.SupplyId)
                    .HasConstraintName("FK__supply_x___suppl__40058253");

            });

            modelBuilder.Entity<SupplyXSupplyPictogramModel>(entity =>
            {
                entity.HasKey(e => new { e.SupplyId, e.SupplyPictogramId });

                entity.ToTable("supply_x_supply_pictograms");

                entity.Property(e => e.SupplyId).HasColumnName("supply_id");

                entity.Property(e => e.SupplyPictogramId).HasColumnName("supply_pictogram_id");

                entity.HasOne(d => d.Supply)
                    .WithMany(d => d.SupplyXSupplyPictogram)
                    .HasForeignKey(d => d.SupplyId)
                    .HasConstraintName("FK__supply_x___suppl__40F9A68C");

                entity.HasOne(d => d.SupplyPictogram)
                    .WithMany(d => d.SupplyXSupplyPictogram)
                    .HasForeignKey(d => d.SupplyPictogramId)
                    .HasConstraintName("FK__supply_x___suppl__41EDCAC5");
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
                    .HasConstraintName("FK__unit_meas__base___42E1EEFE");
            });

            modelBuilder.Entity<UnitMeasuresXSupplyModel>(entity =>
            {                
                entity.ToTable("unit_measures_x_supply");

                entity.Property(e => e.SupplyId).HasColumnName("supply_id");

                entity.Property(e => e.UnitMeasureId).HasColumnName("unit_measure_id");

                entity.HasOne(d => d.Supply)
                    .WithMany(d => d.UnitMeasuresXSupply)
                    .HasForeignKey(d => d.SupplyId)
                    .HasConstraintName("FK__unit_meas__suppl__43D61337");

                entity.HasOne(d => d.UnitMeasure)
                    .WithMany(d => d.UnitMeasuresXSupply)
                    .HasForeignKey(d => d.UnitMeasureId)
                    .HasConstraintName("FK__unit_meas__unit___44CA3770");

                entity.HasKey(t => new { t.SupplyId, t.UnitMeasureId });
            });

            modelBuilder.Entity<UserModel>(entity =>
            {
                entity.ToTable("users");

                entity.HasIndex(e => e.Email, "UQ__users__AB6E61646E2EAF53")
                    .IsUnique();

                entity.HasIndex(e => e.DocumentNumber, "UQ__users__C8FE0D8C4E4B15DA")
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

                entity.Property(e => e.ForgotPasswordToken)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("forgot_password_token");

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
                    .HasConstraintName("FK__users__role_id__45BE5BA9");

                entity.HasOne(d => d.TypeDocument)
                    .WithMany(p => p.Users)
                    .HasForeignKey(d => d.TypeDocumentId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__users__type_docu__46B27FE2");
            });

            modelBuilder.Entity<WarehouseModel>(entity =>
            {
                entity.ToTable("warehouse");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.TypeServiceId).HasColumnName("type_services_id");
                entity.HasOne(d => d.TypeServices)
                    .WithMany(p => p.Warehouses)
                    .HasForeignKey(d => d.TypeServiceId)
                    .HasConstraintName("FK__warehouse__wareh__47A6A41B");
           

            entity.Property(e => e.StatedAt)
                    .HasColumnName("stated_at")
                    .HasDefaultValueSql("((1))");

                entity.Property(e => e.Ubication)
                    .HasMaxLength(150)
                    .IsUnicode(false)
                    .HasColumnName("ubication");

            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
