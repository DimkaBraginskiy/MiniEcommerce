using Ecommerce.core.Interface;
using Ecommerce.core.Service;
using Ecommerce.infrastructure.Data;
using Ecommerce.infrastructure.Repository;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var baseConnection = builder.Configuration.GetConnectionString("Default");
var password = builder.Configuration["DbPassword"];
var connectionString = baseConnection!.Replace("PASSWORD", password);

builder.Services.AddControllers();

builder.Services.AddScoped<ITypeService, TypeService>();

builder.Services.AddScoped<ITypeRepository, TypeRepository>();

builder.Services.AddDbContext<EcommerceDbContext>(options =>
    options.UseNpgsql(connectionString));

var app = builder.Build();

app.MapControllers();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.Run();