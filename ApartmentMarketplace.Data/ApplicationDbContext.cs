using ApartmentMarketplace.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace ApartmentMarketplace.Data;

public class ApplicationDbContext : DbContext
{
    public ApplicationDbContext(DbContextOptions options) : base(options)
    {
    }

    public DbSet<Apartment> Apartments { get; }
    
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(GetType().Assembly);
    }
}