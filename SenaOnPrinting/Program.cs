using BusinessCape.Services;
using BusinessCape.Entensions;
using PersistenceCape.Interfaces;
using PersistenceCape.Repositories;
using BusinessCape.Mappers;

var builder = WebApplication.CreateBuilder(args);
var Configuration = builder.Configuration;
// Add services to the container.
builder.Services.AddInjectionInfraestructure(Configuration);

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

// Configurar las interfaces para que el controlador las pueda usar

builder.Services.AddScoped<OrderProductionService>();
builder.Services.AddScoped<IOrderProductionRepository, OrderProductionRepository>();

builder.Services.AddScoped<LineatureService>();
builder.Services.AddScoped<ILineatureRepository, LineatureRepository>();

builder.Services.AddScoped<ImpositionPlanchService>();
builder.Services.AddScoped<IImpositionPlanchRepository, ImpositionPlanchRepository>();

builder.Services.AddAutoMapper(typeof(AutoMapperProfiles).Assembly);

var app = builder.Build();

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
