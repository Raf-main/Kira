using MediatR;

namespace Kira.Flight.Application.Commands.Airports.CreateAirport;

public class CreateAirportCommand : IRequest<Guid>
{
    public string Name { get; set; } = null!;
}