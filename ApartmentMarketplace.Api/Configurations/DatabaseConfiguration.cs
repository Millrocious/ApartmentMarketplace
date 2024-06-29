using ApartmentMarketplace.Data;
using ApartmentMarketplace.Domain.Common.Constants;
using Microsoft.EntityFrameworkCore;

namespace ApartmentMarketplace.Api.Configurations;

public static class DatabaseConfiguration
{
    public static IServiceCollection ConfigureDatabase(
        this IServiceCollection services,
        IConfiguration configuration)
    {
        services.AddDbContext<ApplicationDbContext>(options =>
            options.UseNpgsql(configuration.GetConnectionString(ConnectionStringsConstants.DatabaseConnection)!));

        return services;
    }
}