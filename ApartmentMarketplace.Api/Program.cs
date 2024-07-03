using ApartmentMarketplace.Api.Configurations;
using ApartmentMarketplace.Data;
using Microsoft.AspNetCore.Cors;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddCors(options =>
{
    options.AddDefaultPolicy(b => {
        b.WithOrigins("http://localhost:5173");
        b.AllowAnyMethod();
        b.AllowAnyHeader();
    });
});

builder.Services
    .ConfigureRepositories()
    .ConfigureServices()
    .ConfigureMappers()
    .ConfigureDatabase(builder.Configuration);

var app = builder.Build();

await app.UseDatabaseMigrations();

app.Seed();

app.UseSwagger();
app.UseSwaggerUI();

app.MapControllers();
app.UseExceptionHandler(_ => { });

app.UseCors();

app.Run();
