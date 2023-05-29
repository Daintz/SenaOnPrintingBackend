
using BusinessCape.Entensions;
using PersistenceCape.Interfaces;
using PersistenceCape.Repositories;
using BusinessCape.Mappers;
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

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();



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
