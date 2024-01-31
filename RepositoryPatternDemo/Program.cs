using Microsoft.EntityFrameworkCore;
using RepositoryPatternDemo.Database;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// 1. Hämta connection string
string? connectionString = builder.Configuration.GetConnectionString("DbConnection");
// 2. Lägg till databasen i Dependincy Connection container
builder.Services.AddDbContext<AppDbContext>(options => options.UseSqlServer(connectionString));
// SOLID // Dependency inversion principle.


var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
	app.UseSwagger();
	app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
