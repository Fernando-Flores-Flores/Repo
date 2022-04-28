
using Microsoft.EntityFrameworkCore;
using Repo.Data;
using Repo.Models;
using Repo.Repositorio.IRepository;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddCors();
// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
//builder.Services.AddDbContext<ApplicationDBContext>(opciones => opciones.UseSqlServer(builder.Configuration.GetConnectionString("conexionDB")));
builder.Services.AddDbContext<BDReportesContext>(opciones => opciones.UseSqlServer(builder.Configuration.GetConnectionString("conexionDB")));

builder.Services.AddScoped<IPersonaRepository, PersonaRepository>();


var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}
app.UseCors(options => { options.WithOrigins("http://localhost:4200");
    options.AllowAnyMethod();
    options.AllowAnyHeader();
});
app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
