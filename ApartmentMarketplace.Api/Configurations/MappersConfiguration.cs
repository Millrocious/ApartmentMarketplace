using ApartmentMarketplace.Application.AutoMapperProfiles;

namespace ApartmentMarketplace.Api.Configurations;

public static class MappersConfiguration
{
    public static IServiceCollection ConfigureMappers(this IServiceCollection services)
    {
        services.AddAutoMapper(typeof(ApartmentProfile).Assembly);

        return services;
    }
}