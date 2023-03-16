using Kira.Domain.Shared.Abstractions;

namespace Kira.Flight.Domain.Entities;

public class Seat : Aggregate<Guid>
{
    public string SeatNumber { get; protected set; } = null!;
    public Guid FlightId { get; protected set; }
    public bool IsReserved { get; protected set; }

    public static Seat Create(string seatNumber, Guid flightId, bool isReserved = false)
    {
        var seat = new Seat
        {
            SeatNumber = seatNumber,
            FlightId = flightId,
            IsReserved = isReserved
        };

        return seat;
    }

    public void ReserveSeat()
    {
        if(IsReserved)
    }
}