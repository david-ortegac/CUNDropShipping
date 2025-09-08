using CUNDropShipping.adapter.restful.v1.controller.Mapper;
using CunDropShipping.application.Service;
using CunDropShipping.Controllers.Entity;
using CUNDropShipping.domain;
using CunDropShipping.domain.Mapper;
using CUNDropShipping.infraestructure.DbContext;
using CUNDropShipping.infraestructure.Entity;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// Registrar DbContext con cadena de conexión
builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseMySql(
        builder.Configuration.GetConnectionString("DefaultConnection"),
        new MySqlServerVersion(new Version(8, 0, 39)) // ajusta a tu versión de MySQL
    )
);

// Registra tus dependencias de infraestructura (según tus tipos reales)
builder.Services.AddScoped<IRepository>();
builder.Services.AddScoped<IInfraestructureMapper, InfraestructureMapper>();
builder.Services.AddScoped<IAdapterMapper, AdapterMapper>();
builder.Services.AddScoped<IProductService, ProductServiceImp>();

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