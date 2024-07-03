using ApartmentMarketplace.Data;
using ApartmentMarketplace.Domain.Entities;

namespace ApartmentMarketplace.Api.Configurations;

public static class ApartmentsInitializer
{
    public static WebApplication Seed(this WebApplication app)
    {
        using var scope = app.Services.CreateScope();
        using var context = scope.ServiceProvider.GetRequiredService<ApplicationDbContext>();

        try
        {
            context.Database.EnsureCreated();

            var apartments = context.Apartments.FirstOrDefault();

            if (apartments == null)
            {
                context.Apartments.AddRange(
                    new Apartment
                        { Name = "Apartment 1", Rooms = 2, Price = 1111, Description = "This is Apartment 1" },
                    new Apartment
                        { Name = "Apartment 2", Rooms = 2, Price = 1100, Description = "This is Apartment 2" },
                    new Apartment
                        { Name = "Apartment 3", Rooms = 3, Price = 1721, Description = "This is Apartment 3" },
                    new Apartment 
                        { Name = "Apartment 4", Rooms = 1, Price = 505, Description = "" }
                );

                context.SaveChanges();
            }
        }
        catch (Exception e)
        {
            throw;
        }
        
        return app;
    }
}