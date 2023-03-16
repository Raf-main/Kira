using MediatR;

namespace Kira.Flight.Application.Features.Seats.ReserveSeat;

public class ReserveSeatCommand : IRequest
{
    public Guid SeatId { get; set; }
}