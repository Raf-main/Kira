using MediatR;

namespace Kira.Flight.Application.Commands.Seats.ReserveSeat;

public class ReserveSeatCommand : IRequest<Unit>
{
    public Guid SeatId { get; set; }
}