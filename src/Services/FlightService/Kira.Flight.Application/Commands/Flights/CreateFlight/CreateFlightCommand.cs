using MediatR;

namespace Kira.Flight.Application.Commands.Flights.CreateFlight;

public class CreateFlightCommand : IRequest<Guid>
{
    public Guid PlaneId { get; set; }
    public Guid FromAirportId { get; set; }
    public Guid ToAirportId { get; set; }
    public decimal Price { get; set; }
    public DateTimeOffset DateTime { get; set; }
}