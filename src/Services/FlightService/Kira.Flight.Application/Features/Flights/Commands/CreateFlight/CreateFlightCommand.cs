using MediatR;

namespace Kira.Flight.Application.Features.Flights.Commands.CreateFlight
{
    public record CreateFlightCommand(Guid PlaneId, Guid FromAirportId, Guid ToAirportId, decimal Price, DateTimeOffset DateTime) : IRequest<Guid>;
}
