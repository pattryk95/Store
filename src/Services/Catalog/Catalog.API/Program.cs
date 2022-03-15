using Catalog.API;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();

builder.Services.AddSwaggerGen();

builder.Services.AddScoped<ICatalogContext, CatalogContext>();
builder.Services.AddScoped<IProductRepository, ProductRepository>();

var app = builder.Build();

// Configure the HTTP request pipeline.

app.UseSwagger();

app.UseSwaggerUI(configuration =>
{
    configuration.SwaggerEndpoint("/swagger/v1/swagger.json", "Catalog API"); // args: default path to swagger file, API docs name
});

app.UseAuthorization();

app.MapControllers();

app.Run();
