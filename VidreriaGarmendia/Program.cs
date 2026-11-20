using Microsoft.EntityFrameworkCore;
using VidreriaGarmendia.Data;

var builder = WebApplication.CreateBuilder(args);

// ---------- Base de datos (Azure SQL: servidor adminvidreria / BD bdvidreria) ----------
var connectionString = builder.Configuration.GetConnectionString("AzureSQL")
    ?? throw new InvalidOperationException("Falta la cadena de conexión 'AzureSQL'.");

builder.Services.AddDbContext<VidreriaDbContext>(options =>
    options.UseSqlServer(connectionString, sql => sql.EnableRetryOnFailure()));

// ---------- CORS: permite que el formulario Contáctenos (Static Web App) llame a la API ----------
// Para producción reemplaza AllowAnyOrigin() por .WithOrigins("https://TU-STATIC-WEB-APP.azurestaticapps.net")
builder.Services.AddCors(options =>
{
    options.AddPolicy("FormularioContactenos", policy =>
        policy.AllowAnyOrigin()
              .AllowAnyHeader()
              .AllowAnyMethod());
});

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Publicar la página principal desde wwwroot/index.html.
app.UseDefaultFiles();
app.UseStaticFiles();

// Swagger habilitado también en Azure para poder probar la API publicada.
app.UseSwagger(c =>
{
    c.SerializeAsV2 = true;
});
app.UseSwaggerUI();
app.UseHttpsRedirection();
app.UseCors("FormularioContactenos");
app.UseAuthorization();

app.MapControllers();


app.Run();
