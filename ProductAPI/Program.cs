using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Npgsql;
using ProductAPI.Config;
using ProductAPI.DependencyInjection;
using Repository.Common;
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
//Mapper config
IMapper mapper = AutoMapperConfig.RegisterMaps().CreateMapper();
builder.Services.AddSingleton(mapper);
builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());
//injetor de dependencia
DependencyInjection.Register(builder.Services);

builder.Services.AddControllers()
    .AddNewtonsoftJson(opt => opt.SerializerSettings.ReferenceLoopHandling =
    Newtonsoft.Json.ReferenceLoopHandling.Ignore);

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
