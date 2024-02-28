using MediatR;

namespace Kira.Flight.Application.Features.Seats.Commands.CreateSeat
{
    public record CreateSeatCommand : IRequest<Guid>
    {
        public CreateSeatCommand(string SeatNumber, Guid FlightId)
        {
            this.SeatNumber = SeatNumber;
            this.FlightId = FlightId;
        }

        public string SeatNumber { get; init; }
        public Guid FlightId { get; init; }

        public void Deconstruct(out string SeatNumber, out Guid FlightId)
        {
            SeatNumber = this.SeatNumber;
            FlightId = this.FlightId;
        }
    }
}
