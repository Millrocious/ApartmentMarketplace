namespace ApartmentMarketplace.Application.Dtos.Apartment;

public class ApartmentResponseDto
{
    public required string Id { get; set; }
    public int Rooms { get; set; }
    public required string Name { get; set; }
    public decimal Price { get; set; }
    public required string Description { get; set; }
}