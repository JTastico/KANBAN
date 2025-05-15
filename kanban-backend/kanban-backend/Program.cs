using kanban_backend.Domain.Interfaces;
using kanban_backend.Infrastructure.Adapters.Repositories;
using kanban_backend.Infrastructure.Data.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;

var builder = WebApplication.CreateSlimBuilder(args);


// Add services to the container.
builder.Services.AddControllersWithViews();




// Add services to the container
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(options =>
{
    options.SwaggerDoc("v1", new Microsoft.OpenApi.Models.OpenApiInfo
    {
        Title = "Mi API",
        Version = "v1",
        Description = "Documentación de la API generada con Swagger en .NET 9"
    });
});
builder.Services.AddDbContext<ApplicationDbContext> ((serviceProvider,options) =>
{
    var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");
    options.UseNpgsql(connectionString);
    
});
builder.Services.AddScoped<ICarreraRepository, CarreraRepository>();
//builder clase
builder.Services.AddScoped<IClaseRepository, ClaseRepository>();
//builder comentarios
builder.Services.AddScoped<IComentarioRepository, ComentarioRepository>();
//builder grupos
builder.Services.AddScoped<IGrupoRepository, GrupoRepository>();
//builder historial
builder.Services.AddScoped<IHistorialMovRepository, HistorialMovRepository>();
//builder Persona
builder.Services.AddScoped<IPersonaRepository, PersonaRepository>();
//builder Proyecto
builder.Services.AddScoped<IProyectoRepository, ProyectoRepository>();
//builder Rol
builder.Services.AddScoped<IRolRepository, RolRepository>();
//builder Tareas
builder.Services.AddScoped<ITareasRepository, TareasRepository>();
//builder UserRol
builder.Services.AddScoped<IUserRolRepository, UserRolRepository>();
//builder Usuario
builder.Services.AddScoped<IUsuarioRepository, UsuarioRepository>();



var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI(options =>
    {
        options.SwaggerEndpoint("/swagger/v1/swagger.json", "Mi API v1");
        options.RoutePrefix = String.Empty; // Así puedes acceder desde /swagger
    });
}

app.UseAuthorization();



app.MapControllers();

app.Run();