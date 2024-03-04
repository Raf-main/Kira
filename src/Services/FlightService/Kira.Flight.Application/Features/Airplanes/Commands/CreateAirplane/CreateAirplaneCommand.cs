using MediatR;

namespace Kira.Flight.Application.Features.Airplanes.Commands.CreateAirplane
{
    public record CreateAirplaneCommand(string Name, string Model) : IRequest<Guid>;
}
