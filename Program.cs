using cube_api.Data;
using cube_api.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// Registro de servicios personalizados (conexión a SSAS y servicio de datos)
builder.Services.AddSingleton<CubeConnection>();  // Servicio de conexión al cubo
builder.Services.AddScoped<CubeDataService>();    // Servicio de consultas al cubo

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI(c =>
    {
        c.SwaggerEndpoint("/swagger/v1/swagger.json", "cube-api v1");
        // Opcional: Establecer la ruta predeterminada de Swagger
        c.RoutePrefix = string.Empty; // Esto habilita Swagger en la raíz del sitio web
    });
}

app.UseAuthorization();

app.MapControllers();

app.Run();
