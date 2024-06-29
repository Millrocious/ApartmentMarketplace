using ApartmentMarketplace.Api.Configurations;
using ApartmentMarketplace.Data;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);
{
    builder.Services.AddControllers();
    builder.Services.AddEndpointsApiExplorer();
    builder.Services.AddSwaggerGen();
    
    builder.Services.AddDbContext<ApplicationDbContext>(options =>
        options.UseNpgsql(builder.Configuration.GetConnectionString("DefaultConnection")));

    builder.Services
        .ConfigureRepositories()
        .ConfigureServices();
}

var app = builder.Build();
{
    app.UseSwagger();
    app.UseSwaggerUI();

    app.Run();
}