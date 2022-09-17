using Microsoft.EntityFrameworkCore;
using Npgsql;
using ProductAPI.Repository.Common;
using System.Data.Common;

var builder = WebApplication.CreateBuilder(args);


// Conexao com banco
var connectionString = builder.Configuration.GetConnectionString("App");
DbConnection dbConnection = new NpgsqlConnection(connectionString);

builder.Services.AddDbContext<ApplicationDbContext>(options =>
{
    options.UseNpgsql(dbConnection, assembly =>
    assembly.MigrationsAssembly(typeof(ApplicationDbContext).Assembly.FullName));
});

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

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
