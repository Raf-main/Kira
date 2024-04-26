using AutoMapper;

using Kira.Flight.Application.Features.Seats.Dto;
using Kira.Flight.Domain.Entities;

namespace Kira.Flight.Application.Features.Seats.Mappings;

public class SeatMapper : Profile
{
    public SeatMapper()
    {
        CreateMap<Seat, SeatDto>();
    }
}
