using ApartmentMarketplace.Domain.Entities;

namespace ApartmentMarketplace.Domain.Interfaces.Repositories;

public interface IApartmentRepository
{
    ValueTask<Apartment?> GetApartmentIdAsync(string id);
    Task<List<Apartment>> GetAllApartmentsAsync();
    Task<Apartment> AddApartmentAsync(Apartment apartment);
    Task UpdateApartmentAsync(Apartment apartment);
    Task DeleteApartmentAsync(Apartment apartment);
}