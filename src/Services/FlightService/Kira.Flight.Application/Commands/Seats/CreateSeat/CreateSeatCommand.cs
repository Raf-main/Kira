using MediatR;

namespace Kira.Flight.Application.Commands.Seats.CreateSeat;

public class CreateSeatCommand : IRequest<Guid>
{
    public string SeatNumber { get; set; } = null!;
    public Guid FlightId { get; set; }
}