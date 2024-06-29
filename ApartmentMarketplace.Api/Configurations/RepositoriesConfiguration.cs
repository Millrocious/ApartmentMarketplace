using ApartmentMarketplace.Data.Repositories;
using ApartmentMarketplace.Domain.Interfaces.Repositories;

namespace ApartmentMarketplace.Api.Configurations;

public static class RepositoriesConfiguration
{
    public static IServiceCollection ConfigureRepositories(this IServiceCollection services)
    {
        services.AddScoped<IApartmentRepository, ApartmentRepository>();

        return services;
    }
        
}