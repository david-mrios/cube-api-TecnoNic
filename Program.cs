using cube_api.Data;
using cube_api.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container
builder.Services.AddControllers();

// Enable Swagger/OpenAPI generation and UI
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(options =>
{
    // Customize Swagger generation options here if needed
    options.SwaggerDoc("v1", new Microsoft.OpenApi.Models.OpenApiInfo
    {
        Title = "Cube API",
        Version = "v1",
        Description = "API for accessing cube data and services",
        Contact = new Microsoft.OpenApi.Models.OpenApiContact
        {
            Name = "David Antonio",  // Replace with your name or organization
            Email = "cbdasi3v33@estu.unan.edu.ni"  // Replace with your email
        }
    });

    // Optionally, add more configuration here if you have more advanced Swagger settings
});

// Register custom services (SSAS connection and data service)
builder.Services.AddSingleton<CubeConnection>();  // Cube connection service
builder.Services.AddScoped<CubeDataService>();    // Cube data query service

var app = builder.Build();

// Configure the HTTP request pipeline
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

// Enable Authorization middleware (you can add authentication if needed later)
app.UseAuthorization();

// Map API controllers
app.MapControllers();

app.Run();
    