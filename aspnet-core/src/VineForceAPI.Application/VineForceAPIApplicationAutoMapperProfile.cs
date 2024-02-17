using AutoMapper;
using VineForceAPI.DTOs;
using VineForceAPI.Entities;

namespace VineForceAPI;

public class VineForceAPIApplicationAutoMapperProfile : Profile
{
    public VineForceAPIApplicationAutoMapperProfile()
    {
        CreateMap<Country, CountryDto>();
        CreateMap<CreateUpdateCountryDto,Country>();
        CreateMap<CreateUpdateStateDto, State>();
        CreateMap<State, StateDto>();
    }
}
