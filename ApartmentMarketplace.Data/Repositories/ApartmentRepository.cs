using ApartmentMarketplace.Domain.Common.Constants;
using ApartmentMarketplace.Domain.Entities;
using ApartmentMarketplace.Domain.Interfaces.Repositories;
using Microsoft.EntityFrameworkCore;

namespace ApartmentMarketplace.Data.Repositories;

public class ApartmentRepository : IApartmentRepository
{
    private readonly ApplicationDbContext _dbContext;

    public ApartmentRepository(ApplicationDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public ValueTask<Apartment?> GetApartmentIdAsync(string id) => _dbContext.Apartments.FindAsync(id);

    public async Task<List<Apartment>> GetAllApartmentsAsync(string? price, int? rooms)
    {
        var query = _dbContext.Apartments.AsQueryable();

        if (rooms.HasValue)
        {
            query = query.Where(a => a.Rooms == rooms.Value);
        }

        if (!string.IsNullOrEmpty(price))
        {
            query = price.ToLower() switch
            {
                PriceOrderConstants.Asc => query.OrderBy(a => a.Price),
                PriceOrderConstants.Desc => query.OrderByDescending(a => a.Price),
                _ => query
            };
        }

        return await query.ToListAsync();
    }
    
    public async Task<Apartment> AddApartmentAsync(Apartment apartment)
    {
        var entity = await _dbContext.Apartments.AddAsync(apartment);
        await _dbContext.SaveChangesAsync();

        return entity.Entity;
    }

    public async Task UpdateApartmentAsync(Apartment apartment)
    {
        _dbContext.Apartments.Update(apartment);
        await _dbContext.SaveChangesAsync();
    }

    public async Task DeleteApartmentAsync(Apartment apartment)
    {
        _dbContext.Apartments.Remove(apartment);
        await _dbContext.SaveChangesAsync();
    }
}