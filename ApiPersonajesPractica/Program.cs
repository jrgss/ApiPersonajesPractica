using ApiPersonajesPractica.Data;
using ApiPersonajesPractica.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
string connectionstring = builder.Configuration.GetConnectionString("SqlAzure");
builder.Services.AddTransient<RepositoryPersonajes>();
builder.Services.AddDbContext<PersonajesContext>(options => options.UseSqlServer(connectionstring));

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(options =>
{
    options.SwaggerDoc("v1", new OpenApiInfo
    {
        Title = "Api CRUD DOCTORES",
        Description = "Probando DOCTORES",
        Version = "v1",
        Contact = new OpenApiContact()
        {
            Name = "Jorge Salinero",
            Email = "jorge.salinero@tajamar365.com"
        }
    });
});

var app = builder.Build();
app.UseSwagger();
app.UseSwaggerUI(options =>
{
    options.SwaggerEndpoint(url: "/swagger/v1/swagger.json", name: "Api CRUD DOCTORES");
    options.RoutePrefix = "";
});
// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment()) { 

}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
