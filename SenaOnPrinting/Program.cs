using BusinessCape.Services;
using BusinessCape.Entensions;
using PersistenceCape.Interfaces;
using PersistenceCape.Repositories;
using BusinessCape.Mappers;
using System.Reflection.PortableExecutable;

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

// Configurar las interfaces para que el controlador las pueda usar

builder.Services.AddScoped<SupplyCategoryService>();
builder.Services.AddScoped<ISupplyCategoryRepository, SupplyCategoryRepository>();

builder.Services.AddScoped<OrderProductionService>();
builder.Services.AddScoped<IOrderProductionRepository, OrderProductionRepository>();

builder.Services.AddScoped<LineatureService>();
builder.Services.AddScoped<ILineatureRepository, LineatureRepository>();

builder.Services.AddScoped<ImpositionPlateService>();
builder.Services.AddScoped<IImpositionPlateRepository, ImpositionPlateRepository>();

builder.Services.AddScoped<ClientService>();
builder.Services.AddScoped<IClientsRepository, ClientRepository>();

builder.Services.AddScoped<QuotationClientService>();
builder.Services.AddScoped<IQuotationClientRepository, QuotationClientRepository>();

builder.Services.AddAutoMapper(typeof(AutoMapperProfiles).Assembly);


var app = builder.Build();
app.UseCors("CorsPolicy");

//Use cors
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
