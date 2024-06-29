using ApartmentMarketplace.Application.Dtos.Apartment;

namespace ApartmentMarketplace.Application.Services.Interfaces;

public interface IApartmentService
{
    Task<ApartmentResponseDto> GetApartmentByIdAsync(string id);
    Task<IList<ApartmentResponseDto>> GetAllApartmentsAsync(string? price, int? rooms);
    Task<ApartmentResponseDto> AddApartmentAsync(ApartmentRequestDto newApartment);
    Task UpdateApartmentAsync(string id, ApartmentRequestDto updatedApartment);
    Task DeleteApartmentAsync(string id);
}