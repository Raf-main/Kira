using AutoMapper;

using Kira.Flight.Application.Features.Airplanes.Dto;
using Kira.Flight.Domain.Entities;

namespace Kira.Flight.Application.Features.Airplanes.Mappings;

public class AirplaneMapper : Profile
{
    public AirplaneMapper()
    {
        CreateMap<Airplane, AirplaneDto>();
    }
}
