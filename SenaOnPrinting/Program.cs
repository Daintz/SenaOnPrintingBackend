using BusinessCape.Services;
using BusinessCape.Entensions;
using PersistenceCape.Interfaces;
using PersistenceCape.Repositories;
using BusinessCape.Mappers;
using FluentValidation.AspNetCore;
using BusinessCape.DTOs.Supply.Validators;
using BusinessCape.DTOs.SupplyCategory.Validators;

var builder = WebApplication.CreateBuilder(args);
var Configuration = builder.Configuration;

//===================================================================|SERVICES|==================================================================//

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
builder.Services.AddAutoMapper(typeof(AutoMapperProfiles).Assembly);


builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

//=======================|SUPPLY CATEGORY|======================//
builder.Services.AddScoped<SupplyCategoryService>();
builder.Services.AddScoped<ISupplyCategoryRepository, SupplyCategoryRepository>();
builder.Services.AddControllers().AddFluentValidation(fv => fv.RegisterValidatorsFromAssemblyContaining<SupplyCategoryCreateDtoValidator>());
builder.Services.AddControllers().AddFluentValidation(fv => fv.RegisterValidatorsFromAssemblyContaining<SupplyCategoryUpdateDtoValidator>());
//==============================================================//

//============================|SUPPLY|==========================//
builder.Services.AddScoped<SupplyService>();
builder.Services.AddScoped<ISupplyRepository, SupplyRepository>();
builder.Services.AddControllers().AddFluentValidation(fv => fv.RegisterValidatorsFromAssemblyContaining<SupplyCreateDtoValidator>());
builder.Services.AddControllers().AddFluentValidation(fv => fv.RegisterValidatorsFromAssemblyContaining<SupplyUpdateDtoValidator>());
//==============================================================//

//=============================================================================================================================================//


//===================================================================|BUILDS|==================================================================//

var app = builder.Build();
app.UseCors("CorsPolicy");

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();

//=============================================================================================================================================//
