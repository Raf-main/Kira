using MediatR;

namespace Kira.Flight.Application.Features.Seats.Commands.ReserveSeat
{
    public record ReserveSeatCommand(Guid SeatId) : IRequest<Unit>;
}
