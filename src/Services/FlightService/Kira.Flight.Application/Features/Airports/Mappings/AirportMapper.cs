using AutoMapper;

using Kira.Flight.Application.Features.Airports.Dto;
using Kira.Flight.Domain.Entities;

namespace Kira.Flight.Application.Features.Airports.Mappings;

public class AirportMapper : Profile
{
    public AirportMapper()
    {
        CreateMap<Airport, AirportDto>();
    }
}
