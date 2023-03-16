using Kira.Domain.Shared.Abstractions;

namespace Kira.Flight.Domain.Entities;

public class Flight : Aggregate<Guid>
{
    public Guid AirplaneId { get; protected set; }
    public Guid FromAirportId { get; protected set; }
    public Guid ToAirportId { get; protected set; }
    public decimal Price { get; protected set; }
    public DateTimeOffset UtcDateTime { get; protected set; }

    public static Flight Create(Guid planeId, Guid fromAirportId, Guid toAirportId, decimal price,
        DateTimeOffset dateTime)
    {
        var flight = new Flight
        {
            AirplaneId = planeId,
            FromAirportId = fromAirportId,
            ToAirportId = toAirportId,
            Price = price,
            UtcDateTime = dateTime.UtcDateTime
        };

        return flight;
    }
}