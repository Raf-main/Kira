using AutoMapper;
using Kira.Flight.Application.Features.Airplanes.Dto;
using Kira.Flight.Domain.Entities;

namespace Kira.Flight.Application.Mappers
{
    public class AirplaneMapper : Profile
    {
        private AirplaneMapper()
        {
            CreateMap<Airplane, AirplaneDto>();
        }
    }
}
