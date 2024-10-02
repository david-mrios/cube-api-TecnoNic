using cube_api.Data;
using cube_api.Services;
using Microsoft.OpenApi.Models;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer(); // Necesario para generar la documentación de los endpoints
builder.Services.AddSwaggerGen(c =>
{
    // Configura Swagger para generar la documentación de la API
    c.SwaggerDoc("v1", new OpenApiInfo { Title = "Cube API", Version = "v1" });
});

// Register custom services (SSAS connection and data service)
builder.Services.AddSingleton<CubeConnection>();  // Servicio de conexión al cubo
builder.Services.AddScoped<CubeDataService>();    // Servicio para consultar datos del cubo

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    // Enable Swagger middleware for the development environment
    app.UseSwagger();
    app.UseSwaggerUI(c =>
    {
        c.SwaggerEndpoint("/swagger/v1/swagger.json", "Cube API v1");
        c.RoutePrefix = string.Empty; // Serve Swagger UI at the root of the application
    });
}
else
{
    // Opción para habilitar Swagger en entornos no de desarrollo
    app.UseSwagger();
    app.UseSwaggerUI(c =>
    {
        c.SwaggerEndpoint("/swagger/v1/swagger.json", "Cube API v1");
        c.RoutePrefix = "swagger"; // Serve Swagger UI at /swagger in production
    });
}

// Enable Authorization middleware
app.UseAuthorization();

// Map API controllers
app.MapControllers();

app.Run();
