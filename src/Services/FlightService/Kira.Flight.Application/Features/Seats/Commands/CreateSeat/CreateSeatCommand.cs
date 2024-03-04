using MediatR;

namespace Kira.Flight.Application.Features.Seats.Commands.CreateSeat
{
    public record CreateSeatCommand(string SeatNumber, Guid FlightId) : IRequest<Guid>;
}
