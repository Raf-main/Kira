using AutoMapper;
using Kira.Flight.Application.Features.Seats.Dto;
using Kira.Flight.Domain.Entities;

namespace Kira.Flight.Application.Mappers
{
    public class SeatMapper : Profile
    {
        private SeatMapper()
        {
            CreateMap<Seat, SeatDto>();
        }
    }
}
