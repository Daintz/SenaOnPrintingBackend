using BusinessCape.Services;
using BusinessCape.Entensions;
using PersistenceCape.Interfaces;
using PersistenceCape.Logic;

var builder = WebApplication.CreateBuilder(args);
var Configuration = builder.Configuration;
// Add services to the container.
builder.Services.AddInjectionInfraestructure(Configuration);

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// Configurar las interfaces para que el controlador las pueda usar
builder.Services.AddScoped<UserService>();
builder.Services.AddScoped<IUserRepository, UserRepository>();

var app = builder.Build();

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
