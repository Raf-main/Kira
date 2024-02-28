using MediatR;

namespace Kira.Flight.Application.Features.Airports.Commands.CreateAirport
{
    public record CreateAirportCommand : IRequest<Guid>
    {
        public CreateAirportCommand(string Name)
        {
            this.Name = Name;
        }

        public string Name { get; init; }

        public void Deconstruct(out string Name)
        {
            Name = this.Name;
        }
    }
}
