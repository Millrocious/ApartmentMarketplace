namespace ApartmentMarketplace.Domain.Entities;

public class Apartment
{
    public string Id { get; set; } = Guid.NewGuid().ToString();
    public int Rooms { get; set; }
    public required string Name { get; set; }
    public decimal Price { get; set; }
    public string? Description { get; set; }
}