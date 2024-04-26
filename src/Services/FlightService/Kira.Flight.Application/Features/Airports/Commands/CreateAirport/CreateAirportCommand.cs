using MediatR;

namespace Kira.Flight.Application.Features.Airports.Commands.CreateAirport;

public record CreateAirportCommand(string Name) : IRequest<Guid>;
