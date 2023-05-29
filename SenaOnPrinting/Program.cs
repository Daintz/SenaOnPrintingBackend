
using BusinessCape.Entensions;
using PersistenceCape.Interfaces;
using PersistenceCape.Repositories;
using BusinessCape.Mappers;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using System.Reflection.PortableExecutable;
using BusinessCape.Services;

var builder = WebApplication.CreateBuilder(args);
var Configuration = builder.Configuration;

// Add services to the container.
builder.Services.AddInjectionInfraestructure(Configuration);
builder.Services.AddCors(options =>
{
    options.AddPolicy("CorsPolicy", builder =>
    {
        builder.AllowAnyOrigin()
            .AllowAnyMethod()
            .AllowAnyHeader();
    });
});

//cors
builder.Services.AddCors(options =>
{
    options.AddPolicy("CorsPolicy", builder =>
    {
        builder.AllowAnyOrigin()
        .AllowAnyMethod()
        .AllowAnyHeader();
    });
});

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddScoped<MachineService>();
builder.Services.AddScoped<IMachinesRepository, MachinesRepository>();
builder.Services.AddScoped<FinishServices>();
builder.Services.AddScoped<IFinishs, FinishRepository>();
builder.Services.AddScoped<UnitMesureServices>();
builder.Services.AddScoped<IUnitMesure, UnitMeasurreRepository>();

// Configurar las interfaces para que el controlador las pueda usar

  // Configuration for JWT Authentication
builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme).AddJwtBearer(options =>
{
    options.TokenValidationParameters = new TokenValidationParameters
    {
        ValidateIssuer = true,
        ValidateAudience = true,
        ValidateLifetime = true,
        ValidateIssuerSigningKey = true,
        ValidIssuer = builder.Configuration["Jwt:Issuer"],
        ValidAudience = builder.Configuration["Jwt:Audience"],
        IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(builder.Configuration["Jwt:SecretKey"]))
    };
});


// Configurar las interfaces para que el controlador las pueda usar
// -------------  Quotation Client Detail --------------//
builder.Services.AddScoped<QuotationClientDetailService>();
builder.Services.AddScoped<IQuotationClientDetailRepository, QuotationClientDetailRepository>();
// -------------  Quotation Client --------------//
builder.Services.AddScoped<QuotationClientService>();
builder.Services.AddScoped<IQuotationClientRepository, QuotationClientRepository>();
// -------------  CLIENTS --------------//
builder.Services.AddScoped<ClientService>();
builder.Services.AddScoped<IClientsRepository, ClientRepository>();
// -------------  SUBSTRATES --------------//
builder.Services.AddScoped<SubstrateService>();
builder.Services.AddScoped<ISubstratesRepository, SubstrateRepository>();
// -------------  PAPER CUT --------------//
builder.Services.AddScoped<PaperCutService>();
builder.Services.AddScoped<IPaperCutRepository, PaperCutRepository>();
// -------------  GRAMMAGE CALIBER --------------//
builder.Services.AddScoped<GrammageCaliberService>();
builder.Services.AddScoped<IGrammageCaliberRepository, GrammageCaliberRepository>();

builder.Services.AddScoped<OrderProductionService>();
builder.Services.AddScoped<IOrderProductionRepository, OrderProductionRepository>();

builder.Services.AddScoped<LineatureService>();
builder.Services.AddScoped<ILineatureRepository, LineatureRepository>();

builder.Services.AddScoped<ImpositionPlanchService>();
builder.Services.AddScoped<IImpositionPlanchRepository, ImpositionPlanchRepository>();

//builder.Services.AddScoped<MachineService>();
//builder.Services.AddScoped<IMachinesRepository, MachinesRepository>();

//builder.Services.AddScoped<FinishServices>();
//builder.Services.AddScoped<IFinishs, FinishRepository>();

builder.Services.AddScoped<RoleService>();
builder.Services.AddScoped<IRoleRepository, RoleRepository>();

builder.Services.AddScoped<TypeDocumentService>();
builder.Services.AddScoped<ITypeDocumentRepository, TypeDocumentRepository>();

builder.Services.AddScoped<UserService>();
builder.Services.AddScoped<IUserRepository, UserRepository>();

builder.Services.AddScoped<AuthenticationService>();
builder.Services.AddScoped<IAuthenticationRepository, AuthenticationRepository>();

builder.Services.AddScoped<ProviderService>(); 
builder.Services.AddScoped<IProviderRepository, ProviderRepository>();

builder.Services.AddScoped<WarehauseTypeService>();
builder.Services.AddScoped<IWarehausetypeRepository,WarehauseTypeRepository>();

builder.Services.AddScoped<WarehauseService>();
builder.Services.AddScoped<IWarehauseRepository, WarehauseRepository>();

//builder.Services.AddScoped<SupplyCategoryService>();
//builder.Services.AddScoped<ISupplyCategoryRepository, SupplyCategoryRepository>();

//builder.Services.AddScoped<OrderProductionService>();
//builder.Services.AddScoped<IOrderProductionRepository, OrderProductionRepository>();

//builder.Services.AddScoped<LineatureService>();
//builder.Services.AddScoped<ILineatureRepository, LineatureRepository>();

//builder.Services.AddScoped<ImpositionPlanchService>();
//builder.Services.AddScoped<IImpositionPlanchRepository, ImpositionPlanchRepository>();

//builder.Services.AddScoped<ClientService>();
//builder.Services.AddScoped<IClientsRepository, ClientRepository>();

//builder.Services.AddScoped<QuotationClientService>();
//builder.Services.AddScoped<IQuotationClientRepository, QuotationClientRepository>();



builder.Services.AddAutoMapper(typeof(AutoMapperProfiles).Assembly);


var app = builder.Build();


app.UseCors("CorsPolicy");

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
