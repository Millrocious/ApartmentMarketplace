using ApartmentMarketplace.Application.Dtos.Apartment;
using ApartmentMarketplace.Application.Services.Interfaces;
using ApartmentMarketplace.Domain.Entities;
using ApartmentMarketplace.Domain.Exceptions;
using ApartmentMarketplace.Domain.Interfaces.Repositories;
using AutoMapper;

namespace ApartmentMarketplace.Application.Services.Implementations;

public class ApartmentService : IApartmentService
{
    private readonly IApartmentRepository _apartmentRepository;
    private readonly IMapper _mapper;

    public ApartmentService(IApartmentRepository apartmentRepository, IMapper mapper)
    {
        _apartmentRepository = apartmentRepository;
        _mapper = mapper;
    }

    public async Task<ApartmentResponseDto> GetApartmentByIdAsync(string id)
    {
        var apartment = await GetApartmentOrThrowAsync(id);
        
        return _mapper.Map<ApartmentResponseDto>(apartment);
    }

    public async Task<IList<ApartmentResponseDto>> GetAllApartmentsAsync(string? price, int? rooms)
    {
        var apartments = await _apartmentRepository.GetAllApartmentsAsync(price, rooms);
        
        return _mapper.Map<IList<ApartmentResponseDto>>(apartments);
    }

    public async Task<ApartmentResponseDto> AddApartmentAsync(ApartmentRequestDto newApartment)
    {
        var apartment = await _apartmentRepository.AddApartmentAsync(_mapper.Map<Apartment>(newApartment));
        
        return _mapper.Map<ApartmentResponseDto>(apartment);
    }

    public async Task UpdateApartmentAsync(string id, ApartmentRequestDto updatedApartment)
    {
        var apartment = await GetApartmentOrThrowAsync(id);
        
        _mapper.Map(updatedApartment, apartment);
        
        await _apartmentRepository.UpdateApartmentAsync(apartment);
    }

    public async Task DeleteApartmentAsync(string id)
    {
        var apartment = await GetApartmentOrThrowAsync(id);

        await _apartmentRepository.DeleteApartmentAsync(apartment);
    }
    
    private async Task<Apartment> GetApartmentOrThrowAsync(string id)
    {
        var apartment = await _apartmentRepository.GetApartmentIdAsync(id);

        if (apartment is null)
        {
            throw new NotFoundException("Publisher not found");
        }

        return apartment;
    }
}