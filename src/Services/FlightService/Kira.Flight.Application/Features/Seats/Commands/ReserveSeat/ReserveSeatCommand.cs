using MediatR;

namespace Kira.Flight.Application.Features.Seats.Commands.ReserveSeat
{
    public record ReserveSeatCommand : IRequest<Unit>
    {
        public ReserveSeatCommand(Guid SeatId)
        {
            this.SeatId = SeatId;
        }

        public Guid SeatId { get; init; }

        public void Deconstruct(out Guid SeatId)
        {
            SeatId = this.SeatId;
        }
    }
}
