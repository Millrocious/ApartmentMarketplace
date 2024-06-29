using ApartmentMarketplace.Application.Dtos.Apartment;
using ApartmentMarketplace.Domain.Entities;
using AutoMapper;

namespace ApartmentMarketplace.Application.AutoMapperProfiles;

public class ApartmentProfile : Profile
{
    public ApartmentProfile()
    {
        CreateMap<ApartmentRequestDto, Apartment>()
            .ForMember(o => o.Id, opt => opt.Ignore());
        
        CreateMap<Apartment, ApartmentResponseDto>();
    }
}