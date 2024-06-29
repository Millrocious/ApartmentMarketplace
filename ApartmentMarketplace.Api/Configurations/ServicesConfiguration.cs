using ApartmentMarketplace.Application.Services.Implementations;
using ApartmentMarketplace.Application.Services.Interfaces;

namespace ApartmentMarketplace.Api.Configurations;

public static class ServicesConfiguration
{
    public static IServiceCollection ConfigureServices(this IServiceCollection services)
    {
        services
            .AddScoped<IApartmentService, ApartmentService>();

        return services;
    }
        
}