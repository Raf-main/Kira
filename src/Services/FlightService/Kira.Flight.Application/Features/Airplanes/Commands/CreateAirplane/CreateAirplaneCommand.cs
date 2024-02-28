using MediatR;

namespace Kira.Flight.Application.Features.Airplanes.Commands.CreateAirplane
{
    public record CreateAirplaneCommand : IRequest<Guid>
    {
        public CreateAirplaneCommand(string Name, string Model)
        {
            this.Name = Name;
            this.Model = Model;
        }

        public string Name { get; init; }
        public string Model { get; init; }

        public void Deconstruct(out string Name, out string Model)
        {
            Name = this.Name;
            Model = this.Model;
        }
    }
}
