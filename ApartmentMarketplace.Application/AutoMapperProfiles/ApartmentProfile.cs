using ApartmentMarketplace.Application.Dtos.Apartment;
using ApartmentMarketplace.Domain.Entities;
using AutoMapper;

namespace ApartmentMarketplace.Application.AutoMapperProfiles;

public class ApartmentProfile : Profile
{
    public ApartmentProfile()
    {
        CreateMap<Apartment, ApartmentRequestDto>()
            .ReverseMap()
            .ForMember(o => o.Id, opt => opt.Ignore());
        
        CreateMap<Apartment, ApartmentResponseDto>();
    }
}