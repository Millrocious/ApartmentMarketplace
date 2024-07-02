using System.ComponentModel.DataAnnotations;

namespace ApartmentMarketplace.Application.Dtos.Apartment;

public class ApartmentRequestDto
{
    [Required]
    [Range(1, int.MaxValue, ErrorMessage = "Rooms must be greater than 0")]
    public int Rooms { get; set; }

    [Required]
    [StringLength(98, ErrorMessage = "Name must be less than 99 characters")]
    public required string Name { get; set; }

    [Required]
    [Range(0.01, double.MaxValue, ErrorMessage = "Price must be greater than 0")]
    public decimal Price { get; set; }
    
    [StringLength(998, ErrorMessage = "Description must be less than 999 characters")]
    public string? Description { get; set; }
}