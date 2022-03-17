using Catalog.API;
using Microsoft.OpenApi.Models;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new OpenApiInfo { Title = "Catalog.API", Version = "v1" });
});

builder.Services.AddScoped<ICatalogContext, CatalogContext>();
builder.Services.AddScoped<IProductRepository, ProductRepository>();
builder.Services.AddScoped<CatalogContextSeed>();

var app = builder.Build();

// Configure the HTTP request pipeline.

var scope = app.Services.CreateScope();
var seeder = scope.ServiceProvider.GetRequiredService<CatalogContextSeed>();
seeder.SeedData();
app.UseSwagger();

app.UseSwaggerUI(configuration =>
{
    configuration.SwaggerEndpoint("/swagger/v1/swagger.json", "Catalog.API"); // args: default path to swagger file, API docs name
});

app.UseAuthorization();

app.MapControllers();

app.Run();
