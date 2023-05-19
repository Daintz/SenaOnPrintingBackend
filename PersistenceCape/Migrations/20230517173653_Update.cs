using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PersistenceCape.Migrations
{
    public partial class Update : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "CLIENTS",
                columns: table => new
                {
                    id_client = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    stated_at = table.Column<bool>(type: "bit", nullable: false, defaultValueSql: "('1')"),
                    name = table.Column<string>(type: "varchar(100)", unicode: false, maxLength: 100, nullable: true),
                    phone = table.Column<string>(type: "varchar(20)", unicode: false, maxLength: 20, nullable: true),
                    email = table.Column<string>(type: "varchar(255)", unicode: false, maxLength: 255, nullable: true),
                    center = table.Column<string>(type: "varchar(255)", unicode: false, maxLength: 255, nullable: true),
                    area = table.Column<string>(type: "varchar(255)", unicode: false, maxLength: 255, nullable: true),
                    regional = table.Column<string>(type: "varchar(255)", unicode: false, maxLength: 255, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_CLIENTS", x => x.id_client);
                });

            migrationBuilder.CreateTable(
                name: "FINISHES",
                columns: table => new
                {
                    id_finish = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    stated_at = table.Column<bool>(type: "bit", nullable: false, defaultValueSql: "('1')"),
                    finish_name = table.Column<string>(type: "varchar(255)", unicode: false, maxLength: 255, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_FINISHES", x => x.id_finish);
                });

            migrationBuilder.CreateTable(
                name: "GRAMMAJE_CALIBER",
                columns: table => new
                {
                    id_grammaje_caliber = table.Column<long>(type: "bigint", nullable: false),
                    type_grammaje_caliber = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: false),
                    grammaje_caliber = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GRAMMAJE_CALIBER", x => x.id_grammaje_caliber);
                });

            migrationBuilder.CreateTable(
                name: "IMPOSITION_PLATE",
                columns: table => new
                {
                    id_imposition_plate = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    imposition_plate_name = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: false),
                    scheme = table.Column<byte[]>(type: "varbinary(max)", nullable: false),
                    stated_at = table.Column<bool>(type: "bit", nullable: false, defaultValueSql: "((1))")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_IMPOSITION_PLATE", x => x.id_imposition_plate);
                });

            migrationBuilder.CreateTable(
                name: "LINEATURE",
                columns: table => new
                {
                    id_lineature = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    lineature = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: false),
                    type_point = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: false),
                    other = table.Column<string>(type: "varchar(255)", unicode: false, maxLength: 255, nullable: false),
                    stated_at = table.Column<bool>(type: "bit", nullable: false, defaultValueSql: "((1))")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LINEATURE", x => x.id_lineature);
                });

            migrationBuilder.CreateTable(
                name: "MACHINES",
                columns: table => new
                {
                    id_machine = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    stated_at = table.Column<bool>(type: "bit", nullable: false, defaultValueSql: "('1')"),
                    name = table.Column<string>(type: "varchar(90)", unicode: false, maxLength: 90, nullable: true),
                    minimum_height = table.Column<decimal>(type: "decimal(18,0)", nullable: true),
                    minimum_width = table.Column<decimal>(type: "decimal(18,0)", nullable: true),
                    maximum_height = table.Column<decimal>(type: "decimal(18,0)", nullable: true),
                    maximum_width = table.Column<decimal>(type: "decimal(18,0)", nullable: true),
                    cost_by_unit = table.Column<decimal>(type: "decimal(18,0)", nullable: true),
                    cost_by_hour = table.Column<decimal>(type: "decimal(18,0)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_MACHINES", x => x.id_machine);
                });

            migrationBuilder.CreateTable(
                name: "PAPER_CUT",
                columns: table => new
                {
                    id_paper_cut = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    paper_cut = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: false),
                    stated_at = table.Column<bool>(type: "bit", nullable: false, defaultValueSql: "((1))")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PAPER_CUT", x => x.id_paper_cut);
                });

            migrationBuilder.CreateTable(
                name: "PERMISSIONS",
                columns: table => new
                {
                    id_permission = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    permission = table.Column<string>(type: "varchar(255)", unicode: false, maxLength: 255, nullable: false),
                    stated_at = table.Column<bool>(type: "bit", nullable: false, defaultValueSql: "('1')")
                },
                constraints: table =>
                {
                    table.PrimaryKey("permissions_id_permission_primary", x => x.id_permission);
                });

            migrationBuilder.CreateTable(
                name: "PRODUCTS",
                columns: table => new
                {
                    id_product = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    stated_at = table.Column<bool>(type: "bit", nullable: false, defaultValueSql: "('1')"),
                    type_product = table.Column<string>(type: "varchar(255)", unicode: false, maxLength: 255, nullable: false),
                    name = table.Column<string>(type: "varchar(255)", unicode: false, maxLength: 255, nullable: false),
                    characteristics = table.Column<string>(type: "varchar(255)", unicode: false, maxLength: 255, nullable: false),
                    id_supply = table.Column<long>(type: "bigint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_PRODUCTS", x => x.id_product);
                });

            migrationBuilder.CreateTable(
                name: "PROGRAM",
                columns: table => new
                {
                    id_program = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    program_name = table.Column<long>(type: "bigint", nullable: false),
                    stated_at = table.Column<bool>(type: "bit", nullable: false, defaultValueSql: "((1))")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PROGRAM", x => x.id_program);
                });

            migrationBuilder.CreateTable(
                name: "PROVIDERS",
                columns: table => new
                {
                    id_provider = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    stated_at = table.Column<bool>(type: "bit", nullable: false, defaultValueSql: "('1')"),
                    name_company = table.Column<string>(type: "varchar(255)", unicode: false, maxLength: 255, nullable: false),
                    nit_company = table.Column<long>(type: "bigint", nullable: false),
                    email = table.Column<string>(type: "varchar(255)", unicode: false, maxLength: 255, nullable: false),
                    phone = table.Column<string>(type: "varchar(255)", unicode: false, maxLength: 255, nullable: false),
                    company_address = table.Column<string>(type: "varchar(255)", unicode: false, maxLength: 255, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_PROVIDERS", x => x.id_provider);
                });

            migrationBuilder.CreateTable(
                name: "ROLES",
                columns: table => new
                {
                    id_role = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    name = table.Column<string>(type: "varchar(255)", unicode: false, maxLength: 255, nullable: false),
                    description = table.Column<string>(type: "varchar(255)", unicode: false, maxLength: 255, nullable: false),
                    stated_at = table.Column<bool>(type: "bit", nullable: false, defaultValueSql: "('1')")
                },
                constraints: table =>
                {
                    table.PrimaryKey("roles_id_role_primary", x => x.id_role);
                });

            migrationBuilder.CreateTable(
                name: "SUBSTRATES",
                columns: table => new
                {
                    id_substrate = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    stated_at = table.Column<bool>(type: "bit", nullable: false),
                    substratum_name = table.Column<string>(type: "varchar(200)", unicode: false, maxLength: 200, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_SUBSTRATES", x => x.id_substrate);
                });

            migrationBuilder.CreateTable(
                name: "SUPPLY_CATEGORIES",
                columns: table => new
                {
                    id_supply_category = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    name = table.Column<string>(type: "varchar(255)", unicode: false, maxLength: 255, nullable: false),
                    description = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    stated_at = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("supply_categories_id_supply_category_primary", x => x.id_supply_category);
                });

            migrationBuilder.CreateTable(
                name: "SUPPLY_PICTOGRAMS",
                columns: table => new
                {
                    id_pictogram = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    name = table.Column<string>(type: "varchar(255)", unicode: false, maxLength: 255, nullable: false),
                    pictogram = table.Column<byte[]>(type: "varbinary(max)", nullable: false),
                    stated_at = table.Column<bool>(type: "bit", nullable: false, defaultValueSql: "('1')")
                },
                constraints: table =>
                {
                    table.PrimaryKey("supply_pictograms_id_pictogram_primary", x => x.id_pictogram);
                });

            migrationBuilder.CreateTable(
                name: "TYPE_DOCUMENTS",
                columns: table => new
                {
                    id_type_document = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    name = table.Column<string>(type: "varchar(255)", unicode: false, maxLength: 255, nullable: false),
                    abbreviation = table.Column<string>(type: "varchar(255)", unicode: false, maxLength: 255, nullable: false),
                    stated_at = table.Column<bool>(type: "bit", nullable: false, defaultValueSql: "('1')")
                },
                constraints: table =>
                {
                    table.PrimaryKey("type_documents_id_type_document_primary", x => x.id_type_document);
                });

            migrationBuilder.CreateTable(
                name: "TYPE_SERVICE",
                columns: table => new
                {
                    id_type_service = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    stated_at = table.Column<bool>(type: "bit", nullable: false, defaultValueSql: "('1')"),
                    name = table.Column<string>(type: "varchar(255)", unicode: false, maxLength: 255, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_TYPE_SERVICE", x => x.id_type_service);
                });

            migrationBuilder.CreateTable(
                name: "UNIT_MEASURES",
                columns: table => new
                {
                    id_unit_measur = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    name = table.Column<string>(type: "varchar(255)", unicode: false, maxLength: 255, nullable: false),
                    abbreviation = table.Column<int>(type: "int", nullable: false),
                    type = table.Column<int>(type: "int", nullable: false),
                    base_id = table.Column<long>(type: "bigint", nullable: true),
                    conversion_factor = table.Column<decimal>(type: "decimal(8,2)", nullable: false),
                    stated_at = table.Column<bool>(type: "bit", nullable: false, defaultValueSql: "('1')")
                },
                constraints: table =>
                {
                    table.PrimaryKey("unit_measures_id_unit_measur_primary", x => x.id_unit_measur);
                });

            migrationBuilder.CreateTable(
                name: "WAREHOUSE_TYPE",
                columns: table => new
                {
                    id_type_warehouse = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    stated_at = table.Column<bool>(type: "bit", nullable: false, defaultValueSql: "('1')"),
                    nametype = table.Column<string>(type: "varchar(max)", unicode: false, nullable: true),
                    description = table.Column<string>(type: "varchar(max)", unicode: false, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_Tbl", x => x.id_type_warehouse);
                });

            migrationBuilder.CreateTable(
                name: "QUOTATION_PROVIDERS",
                columns: table => new
                {
                    id_quotation_provider = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    date = table.Column<DateTime>(type: "date", nullable: true),
                    quotation_file = table.Column<byte[]>(type: "varbinary(max)", nullable: true),
                    full_value = table.Column<double>(type: "float", nullable: true),
                    id_provider = table.Column<long>(type: "bigint", nullable: true),
                    stated_at = table.Column<bool>(type: "bit", nullable: false, defaultValueSql: "('1')")
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_QUOTATION_PROVIDERS", x => x.id_quotation_provider);
                    table.ForeignKey(
                        name: "id_provider",
                        column: x => x.id_provider,
                        principalTable: "PROVIDERS",
                        principalColumn: "id_provider");
                });

            migrationBuilder.CreateTable(
                name: "PERMISSIONS_X_ROLES",
                columns: table => new
                {
                    id_permission = table.Column<long>(type: "bigint", nullable: false),
                    id_role = table.Column<long>(type: "bigint", nullable: false)
                },
                constraints: table =>
                {
                    table.ForeignKey(
                        name: "permissions_x_roles_id_permission_foreign",
                        column: x => x.id_permission,
                        principalTable: "PERMISSIONS",
                        principalColumn: "id_permission");
                    table.ForeignKey(
                        name: "permissions_x_roles_id_role_foreign",
                        column: x => x.id_role,
                        principalTable: "ROLES",
                        principalColumn: "id_role");
                });

            migrationBuilder.CreateTable(
                name: "USERS",
                columns: table => new
                {
                    id_user = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    document_number = table.Column<string>(type: "varchar(255)", unicode: false, maxLength: 255, nullable: false),
                    surnames = table.Column<string>(type: "nchar(255)", fixedLength: true, maxLength: 255, nullable: false),
                    last_names = table.Column<string>(type: "varchar(1)", unicode: false, maxLength: 1, nullable: false),
                    phone = table.Column<string>(type: "varchar(1)", unicode: false, maxLength: 1, nullable: false),
                    address = table.Column<string>(type: "varchar(1)", unicode: false, maxLength: 1, nullable: false),
                    email = table.Column<string>(type: "varchar(1)", unicode: false, maxLength: 1, nullable: false),
                    password_digest = table.Column<string>(type: "varchar(1)", unicode: false, maxLength: 1, nullable: false),
                    id_role = table.Column<long>(type: "bigint", nullable: false),
                    id_type_document = table.Column<long>(type: "bigint", nullable: false),
                    stated_at = table.Column<bool>(type: "bit", nullable: false, defaultValueSql: "('1')")
                },
                constraints: table =>
                {
                    table.PrimaryKey("users_id_user_primary", x => x.id_user);
                    table.ForeignKey(
                        name: "users_id_role_foreign",
                        column: x => x.id_role,
                        principalTable: "ROLES",
                        principalColumn: "id_role");
                    table.ForeignKey(
                        name: "users_id_type_document_foreign",
                        column: x => x.id_type_document,
                        principalTable: "TYPE_DOCUMENTS",
                        principalColumn: "id_type_document");
                });

            migrationBuilder.CreateTable(
                name: "WAREHOUSE",
                columns: table => new
                {
                    id_warehouse = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    name = table.Column<string>(type: "varchar(255)", unicode: false, maxLength: 255, nullable: false),
                    ubication = table.Column<string>(type: "varchar(255)", unicode: false, maxLength: 255, nullable: false),
                    stated_at = table.Column<bool>(type: "bit", nullable: false, defaultValueSql: "('1')"),
                    id_type_warehouse = table.Column<long>(type: "bigint", nullable: true),
                    IdTypeWarehouseNavigationIdTypeWarehouse = table.Column<long>(type: "bigint", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("warehouse_id_warehouse_primary", x => x.id_warehouse);
                    table.ForeignKey(
                        name: "FK_WAREHOUSE_WAREHOUSE_TYPE_IdTypeWarehouseNavigationIdTypeWarehouse",
                        column: x => x.IdTypeWarehouseNavigationIdTypeWarehouse,
                        principalTable: "WAREHOUSE_TYPE",
                        principalColumn: "id_type_warehouse");
                });

            migrationBuilder.CreateTable(
                name: "QUOTATION_CLIENTS",
                columns: table => new
                {
                    id_quotation_client = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    id_user = table.Column<long>(type: "bigint", nullable: true),
                    id_client = table.Column<long>(type: "bigint", nullable: true),
                    id_machine = table.Column<long>(type: "bigint", nullable: true),
                    id_type_service = table.Column<long>(type: "bigint", nullable: true),
                    id_substrate = table.Column<long>(type: "bigint", nullable: true),
                    id_finishes = table.Column<long>(type: "bigint", nullable: true),
                    id_product = table.Column<long>(type: "bigint", nullable: true),
                    date_orde = table.Column<DateTime>(type: "date", nullable: true),
                    deliver_date = table.Column<DateTime>(type: "date", nullable: true),
                    product_quantity = table.Column<int>(type: "int", nullable: true),
                    technical_specifications = table.Column<string>(type: "varchar(255)", unicode: false, maxLength: 255, nullable: true),
                    ink_quantity = table.Column<int>(type: "int", nullable: true),
                    unit_value = table.Column<double>(type: "float", nullable: true),
                    full_value = table.Column<double>(type: "float", nullable: true),
                    product_high = table.Column<double>(type: "float", nullable: true),
                    product_width = table.Column<double>(type: "float", nullable: true),
                    number_of_pages = table.Column<int>(type: "int", nullable: true),
                    stated_at = table.Column<bool>(type: "bit", nullable: false, defaultValueSql: "('1')"),
                    quotation_status = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_QUOTATION_PRODUCTS", x => x.id_quotation_client);
                    table.ForeignKey(
                        name: "FK_QUOTATION_CLIENTS_USERS",
                        column: x => x.id_user,
                        principalTable: "USERS",
                        principalColumn: "id_user");
                    table.ForeignKey(
                        name: "id_client",
                        column: x => x.id_client,
                        principalTable: "CLIENTS",
                        principalColumn: "id_client");
                    table.ForeignKey(
                        name: "id_finish",
                        column: x => x.id_finishes,
                        principalTable: "FINISHES",
                        principalColumn: "id_finish");
                    table.ForeignKey(
                        name: "id_machine",
                        column: x => x.id_machine,
                        principalTable: "MACHINES",
                        principalColumn: "id_machine");
                    table.ForeignKey(
                        name: "id_product",
                        column: x => x.id_product,
                        principalTable: "PRODUCTS",
                        principalColumn: "id_product");
                    table.ForeignKey(
                        name: "id_type_service",
                        column: x => x.id_type_service,
                        principalTable: "TYPE_SERVICE",
                        principalColumn: "id_type_service");
                });

            migrationBuilder.CreateTable(
                name: "SUPPLIES",
                columns: table => new
                {
                    id_supply = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    name = table.Column<string>(type: "varchar(255)", unicode: false, maxLength: 255, nullable: false),
                    minimun_unit_measure_id = table.Column<long>(type: "bigint", nullable: false),
                    danger_indicators = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    use_instructions = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    advices = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    supply_type = table.Column<int>(type: "int", nullable: false),
                    sorting_word = table.Column<int>(type: "int", nullable: false),
                    quantity = table.Column<int>(type: "int", nullable: false),
                    average_cost = table.Column<decimal>(type: "decimal(8,2)", nullable: true),
                    id_warehouse = table.Column<long>(type: "bigint", nullable: false),
                    stated_at = table.Column<bool>(type: "bit", nullable: false, defaultValueSql: "('1')"),
                    IdWarehouseNavigationIdWarehouse = table.Column<long>(type: "bigint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("supplies_id_supply_primary", x => x.id_supply);
                    table.ForeignKey(
                        name: "FK_SUPPLIES_WAREHOUSE_IdWarehouseNavigationIdWarehouse",
                        column: x => x.IdWarehouseNavigationIdWarehouse,
                        principalTable: "WAREHOUSE",
                        principalColumn: "id_warehouse",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ORDER_PRODUCTION",
                columns: table => new
                {
                    id_order_production = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    id_quotation_client = table.Column<long>(type: "bigint", nullable: true),
                    id_user = table.Column<long>(type: "bigint", nullable: true),
                    material_reception = table.Column<string>(type: "varchar(255)", unicode: false, maxLength: 255, nullable: true),
                    id_program = table.Column<long>(type: "bigint", nullable: true),
                    program_version = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    indented = table.Column<double>(type: "float", nullable: true),
                    color_profile = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    special_ink = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    ink_code = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    id_lineature = table.Column<long>(type: "bigint", nullable: true),
                    id_grammage = table.Column<long>(type: "bigint", nullable: true),
                    id_plate_imposition = table.Column<long>(type: "bigint", nullable: true),
                    id_paper_cut_size = table.Column<long>(type: "bigint", nullable: true),
                    image = table.Column<byte[]>(type: "varbinary(max)", nullable: true),
                    observations = table.Column<string>(type: "nvarchar(300)", maxLength: 300, nullable: true),
                    stated_at = table.Column<bool>(type: "bit", nullable: false, defaultValueSql: "('1')"),
                    order_status = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_Tbl_0", x => x.id_order_production);
                    table.ForeignKey(
                        name: "FK_ORDER_PRODUCTION_GRAMMAJE_CALIBER",
                        column: x => x.id_grammage,
                        principalTable: "GRAMMAJE_CALIBER",
                        principalColumn: "id_grammaje_caliber");
                    table.ForeignKey(
                        name: "FK_ORDER_PRODUCTION_IMPOSITION_PLATE",
                        column: x => x.id_plate_imposition,
                        principalTable: "IMPOSITION_PLATE",
                        principalColumn: "id_imposition_plate");
                    table.ForeignKey(
                        name: "FK_ORDER_PRODUCTION_LINEATURE",
                        column: x => x.id_lineature,
                        principalTable: "LINEATURE",
                        principalColumn: "id_lineature");
                    table.ForeignKey(
                        name: "FK_ORDER_PRODUCTION_PAPER_CUT",
                        column: x => x.id_paper_cut_size,
                        principalTable: "PAPER_CUT",
                        principalColumn: "id_paper_cut");
                    table.ForeignKey(
                        name: "FK_ORDER_PRODUCTION_PROGRAM",
                        column: x => x.id_program,
                        principalTable: "PROGRAM",
                        principalColumn: "id_program");
                    table.ForeignKey(
                        name: "id_quotation_products",
                        column: x => x.id_quotation_client,
                        principalTable: "QUOTATION_CLIENTS",
                        principalColumn: "id_quotation_client");
                    table.ForeignKey(
                        name: "id_user",
                        column: x => x.id_user,
                        principalTable: "USERS",
                        principalColumn: "id_user");
                });

            migrationBuilder.CreateTable(
                name: "SUBSTRATE_X_QUOTATION_CLIENT",
                columns: table => new
                {
                    id_substrate = table.Column<long>(type: "bigint", nullable: false),
                    id_quotation_client = table.Column<long>(type: "bigint", nullable: false)
                },
                constraints: table =>
                {
                    table.ForeignKey(
                        name: "FK_SUBSTRATE_X_QUOTATION_CLIENT_QUOTATION_CLIENTS",
                        column: x => x.id_quotation_client,
                        principalTable: "QUOTATION_CLIENTS",
                        principalColumn: "id_quotation_client");
                    table.ForeignKey(
                        name: "FK_SUBSTRATE_X_QUOTATION_CLIENT_SUBSTRATES",
                        column: x => x.id_substrate,
                        principalTable: "SUBSTRATES",
                        principalColumn: "id_substrate");
                });

            migrationBuilder.CreateTable(
                name: "SUPPLY_CATEGORIES_X_SUPPLY",
                columns: table => new
                {
                    id_supply = table.Column<long>(type: "bigint", nullable: false),
                    id_supply_category = table.Column<long>(type: "bigint", nullable: false)
                },
                constraints: table =>
                {
                    table.ForeignKey(
                        name: "supply_categories_x_supply_id_supply_category_foreign",
                        column: x => x.id_supply_category,
                        principalTable: "SUPPLY_CATEGORIES",
                        principalColumn: "id_supply_category");
                    table.ForeignKey(
                        name: "supply_categories_x_supply_id_supply_foreign",
                        column: x => x.id_supply,
                        principalTable: "SUPPLIES",
                        principalColumn: "id_supply");
                });

            migrationBuilder.CreateTable(
                name: "SUPPLY_DETAILS",
                columns: table => new
                {
                    id_supply_details = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    id_provider = table.Column<long>(type: "bigint", nullable: false),
                    id_supply = table.Column<long>(type: "bigint", nullable: false),
                    stated_at = table.Column<bool>(type: "bit", nullable: false, defaultValueSql: "('1')"),
                    supply_cost = table.Column<decimal>(type: "decimal(8,2)", nullable: false),
                    batch = table.Column<string>(type: "varchar(255)", unicode: false, maxLength: 255, nullable: true),
                    initial_quantity = table.Column<int>(type: "int", nullable: false),
                    entry_date = table.Column<DateTime>(type: "datetime", nullable: false),
                    expiration_date = table.Column<DateTime>(type: "datetime", nullable: false),
                    actual_quantity = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_SUPPLY_DETAILS", x => x.id_supply_details);
                    table.ForeignKey(
                        name: "FK_SUPPLY_DETAILS_PROVIDERS",
                        column: x => x.id_provider,
                        principalTable: "PROVIDERS",
                        principalColumn: "id_provider");
                    table.ForeignKey(
                        name: "id_supply",
                        column: x => x.id_supply,
                        principalTable: "SUPPLIES",
                        principalColumn: "id_supply");
                });

            migrationBuilder.CreateTable(
                name: "SUPPLY_X_PRODUCT",
                columns: table => new
                {
                    id_supply = table.Column<long>(type: "bigint", nullable: false),
                    id_product = table.Column<long>(type: "bigint", nullable: false)
                },
                constraints: table =>
                {
                    table.ForeignKey(
                        name: "FK_SUPPLY_X_PRODUCT_PRODUCTS",
                        column: x => x.id_product,
                        principalTable: "PRODUCTS",
                        principalColumn: "id_product");
                    table.ForeignKey(
                        name: "FK_SUPPLY_X_PRODUCT_SUPPLIES",
                        column: x => x.id_supply,
                        principalTable: "SUPPLIES",
                        principalColumn: "id_supply");
                });

            migrationBuilder.CreateTable(
                name: "SUPPLY_X_SUPPLY_PICTOGRAMS",
                columns: table => new
                {
                    id_supply = table.Column<long>(type: "bigint", nullable: false),
                    id_supply_pictogram = table.Column<long>(type: "bigint", nullable: false)
                },
                constraints: table =>
                {
                    table.ForeignKey(
                        name: "supply_x_supply_pictograms_id_supply_foreign",
                        column: x => x.id_supply,
                        principalTable: "SUPPLIES",
                        principalColumn: "id_supply");
                    table.ForeignKey(
                        name: "supply_x_supply_pictograms_id_supply_pictogram_foreign",
                        column: x => x.id_supply_pictogram,
                        principalTable: "SUPPLY_PICTOGRAMS",
                        principalColumn: "id_pictogram");
                });

            migrationBuilder.CreateTable(
                name: "UNIT_MEASURES_X_SUPPLY",
                columns: table => new
                {
                    id_unit_measure = table.Column<long>(type: "bigint", nullable: false),
                    id_supply = table.Column<long>(type: "bigint", nullable: false)
                },
                constraints: table =>
                {
                    table.ForeignKey(
                        name: "unit_measures_x_supply_id_supply_foreign",
                        column: x => x.id_supply,
                        principalTable: "SUPPLIES",
                        principalColumn: "id_supply");
                    table.ForeignKey(
                        name: "unit_measures_x_supply_id_unit_measure_foreign",
                        column: x => x.id_unit_measure,
                        principalTable: "UNIT_MEASURES",
                        principalColumn: "id_unit_measur");
                });

            migrationBuilder.CreateIndex(
                name: "IX_ORDER_PRODUCTION_id_grammage",
                table: "ORDER_PRODUCTION",
                column: "id_grammage");

            migrationBuilder.CreateIndex(
                name: "IX_ORDER_PRODUCTION_id_lineature",
                table: "ORDER_PRODUCTION",
                column: "id_lineature");

            migrationBuilder.CreateIndex(
                name: "IX_ORDER_PRODUCTION_id_paper_cut_size",
                table: "ORDER_PRODUCTION",
                column: "id_paper_cut_size");

            migrationBuilder.CreateIndex(
                name: "IX_ORDER_PRODUCTION_id_plate_imposition",
                table: "ORDER_PRODUCTION",
                column: "id_plate_imposition");

            migrationBuilder.CreateIndex(
                name: "IX_ORDER_PRODUCTION_id_program",
                table: "ORDER_PRODUCTION",
                column: "id_program");

            migrationBuilder.CreateIndex(
                name: "IX_ORDER_PRODUCTION_id_quotation_client",
                table: "ORDER_PRODUCTION",
                column: "id_quotation_client");

            migrationBuilder.CreateIndex(
                name: "IX_ORDER_PRODUCTION_id_user",
                table: "ORDER_PRODUCTION",
                column: "id_user");

            migrationBuilder.CreateIndex(
                name: "permissions_x_roles_id_permission_unique",
                table: "PERMISSIONS_X_ROLES",
                column: "id_permission",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "permissions_x_roles_id_role_unique",
                table: "PERMISSIONS_X_ROLES",
                column: "id_role",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_QUOTATION_CLIENTS_id_client",
                table: "QUOTATION_CLIENTS",
                column: "id_client");

            migrationBuilder.CreateIndex(
                name: "IX_QUOTATION_CLIENTS_id_finishes",
                table: "QUOTATION_CLIENTS",
                column: "id_finishes");

            migrationBuilder.CreateIndex(
                name: "IX_QUOTATION_CLIENTS_id_machine",
                table: "QUOTATION_CLIENTS",
                column: "id_machine");

            migrationBuilder.CreateIndex(
                name: "IX_QUOTATION_CLIENTS_id_product",
                table: "QUOTATION_CLIENTS",
                column: "id_product");

            migrationBuilder.CreateIndex(
                name: "IX_QUOTATION_CLIENTS_id_type_service",
                table: "QUOTATION_CLIENTS",
                column: "id_type_service");

            migrationBuilder.CreateIndex(
                name: "IX_QUOTATION_CLIENTS_id_user",
                table: "QUOTATION_CLIENTS",
                column: "id_user");

            migrationBuilder.CreateIndex(
                name: "IX_QUOTATION_PROVIDERS_id_provider",
                table: "QUOTATION_PROVIDERS",
                column: "id_provider");

            migrationBuilder.CreateIndex(
                name: "IX_SUBSTRATE_X_QUOTATION_CLIENT_id_quotation_client",
                table: "SUBSTRATE_X_QUOTATION_CLIENT",
                column: "id_quotation_client");

            migrationBuilder.CreateIndex(
                name: "IX_SUBSTRATE_X_QUOTATION_CLIENT_id_substrate",
                table: "SUBSTRATE_X_QUOTATION_CLIENT",
                column: "id_substrate");

            migrationBuilder.CreateIndex(
                name: "IX_SUPPLIES_IdWarehouseNavigationIdWarehouse",
                table: "SUPPLIES",
                column: "IdWarehouseNavigationIdWarehouse");

            migrationBuilder.CreateIndex(
                name: "supplies_id_warehouse_unique",
                table: "SUPPLIES",
                column: "id_warehouse",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "supplies_minimun_unit_measure_id_unique",
                table: "SUPPLIES",
                column: "minimun_unit_measure_id",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "supply_categories_x_supply_id_supply_category_unique",
                table: "SUPPLY_CATEGORIES_X_SUPPLY",
                column: "id_supply_category",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "supply_categories_x_supply_id_supply_unique",
                table: "SUPPLY_CATEGORIES_X_SUPPLY",
                column: "id_supply",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_SUPPLY_DETAILS_id_provider",
                table: "SUPPLY_DETAILS",
                column: "id_provider");

            migrationBuilder.CreateIndex(
                name: "IX_SUPPLY_DETAILS_id_supply",
                table: "SUPPLY_DETAILS",
                column: "id_supply");

            migrationBuilder.CreateIndex(
                name: "IX_SUPPLY_X_PRODUCT_id_product",
                table: "SUPPLY_X_PRODUCT",
                column: "id_product");

            migrationBuilder.CreateIndex(
                name: "IX_SUPPLY_X_PRODUCT_id_supply",
                table: "SUPPLY_X_PRODUCT",
                column: "id_supply");

            migrationBuilder.CreateIndex(
                name: "supply_x_supply_pictograms_id_supply_pictogram_unique",
                table: "SUPPLY_X_SUPPLY_PICTOGRAMS",
                column: "id_supply_pictogram",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "supply_x_supply_pictograms_id_supply_unique",
                table: "SUPPLY_X_SUPPLY_PICTOGRAMS",
                column: "id_supply",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "unit_measures_x_supply_id_supply_unique",
                table: "UNIT_MEASURES_X_SUPPLY",
                column: "id_supply",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "unit_measures_x_supply_id_unit_measure_unique",
                table: "UNIT_MEASURES_X_SUPPLY",
                column: "id_unit_measure",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "users_document_number_unique",
                table: "USERS",
                column: "document_number",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "users_id_role_unique",
                table: "USERS",
                column: "id_role",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "users_id_type_document_unique",
                table: "USERS",
                column: "id_type_document",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_WAREHOUSE_IdTypeWarehouseNavigationIdTypeWarehouse",
                table: "WAREHOUSE",
                column: "IdTypeWarehouseNavigationIdTypeWarehouse");

            migrationBuilder.CreateIndex(
                name: "warehause_id_type_warehouse_unique",
                table: "WAREHOUSE",
                column: "id_type_warehouse",
                unique: true,
                filter: "[id_type_warehouse] IS NOT NULL");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ORDER_PRODUCTION");

            migrationBuilder.DropTable(
                name: "PERMISSIONS_X_ROLES");

            migrationBuilder.DropTable(
                name: "QUOTATION_PROVIDERS");

            migrationBuilder.DropTable(
                name: "SUBSTRATE_X_QUOTATION_CLIENT");

            migrationBuilder.DropTable(
                name: "SUPPLY_CATEGORIES_X_SUPPLY");

            migrationBuilder.DropTable(
                name: "SUPPLY_DETAILS");

            migrationBuilder.DropTable(
                name: "SUPPLY_X_PRODUCT");

            migrationBuilder.DropTable(
                name: "SUPPLY_X_SUPPLY_PICTOGRAMS");

            migrationBuilder.DropTable(
                name: "UNIT_MEASURES_X_SUPPLY");

            migrationBuilder.DropTable(
                name: "GRAMMAJE_CALIBER");

            migrationBuilder.DropTable(
                name: "IMPOSITION_PLATE");

            migrationBuilder.DropTable(
                name: "LINEATURE");

            migrationBuilder.DropTable(
                name: "PAPER_CUT");

            migrationBuilder.DropTable(
                name: "PROGRAM");

            migrationBuilder.DropTable(
                name: "PERMISSIONS");

            migrationBuilder.DropTable(
                name: "QUOTATION_CLIENTS");

            migrationBuilder.DropTable(
                name: "SUBSTRATES");

            migrationBuilder.DropTable(
                name: "SUPPLY_CATEGORIES");

            migrationBuilder.DropTable(
                name: "PROVIDERS");

            migrationBuilder.DropTable(
                name: "SUPPLY_PICTOGRAMS");

            migrationBuilder.DropTable(
                name: "SUPPLIES");

            migrationBuilder.DropTable(
                name: "UNIT_MEASURES");

            migrationBuilder.DropTable(
                name: "USERS");

            migrationBuilder.DropTable(
                name: "CLIENTS");

            migrationBuilder.DropTable(
                name: "FINISHES");

            migrationBuilder.DropTable(
                name: "MACHINES");

            migrationBuilder.DropTable(
                name: "PRODUCTS");

            migrationBuilder.DropTable(
                name: "TYPE_SERVICE");

            migrationBuilder.DropTable(
                name: "WAREHOUSE");

            migrationBuilder.DropTable(
                name: "ROLES");

            migrationBuilder.DropTable(
                name: "TYPE_DOCUMENTS");

            migrationBuilder.DropTable(
                name: "WAREHOUSE_TYPE");
        }
    }
}
