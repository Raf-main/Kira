using AutoMapper;
using Kira.Flight.Application.Features.Airports.Dto;
using Kira.Flight.Domain.Entities;

namespace Kira.Flight.Application.Mappers
{
    public class AirportMapper : Profile
    {
        private AirportMapper()
        {
            CreateMap<Airport, AirportDto>();
        }
    }
}
