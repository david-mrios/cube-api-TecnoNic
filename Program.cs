using cube_api.Data;
using cube_api.Services;
using Microsoft.OpenApi.Models;  // Asegúrate de tener esto para OpenApiInfo

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllers();
builder.Services.AddSwaggerGen();


// Register Swagger/OpenAPI services
builder.Services.AddEndpointsApiExplorer();

// Register custom services (SSAS connection and data service)
builder.Services.AddSingleton<CubeConnection>();  // Cube connection service
builder.Services.AddScoped<CubeDataService>();    // Cube data query service

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
    // Optionally, you can add the Swagger in non-development environments as well
    app.UseSwagger();
    app.UseSwaggerUI(c =>
    {
        c.SwaggerEndpoint("/swagger/v1/swagger.json", "Cube API v1");
    });
}

// Enable Authorization middleware
app.UseAuthorization();

// Map API controllers
app.MapControllers();

app.Run();
