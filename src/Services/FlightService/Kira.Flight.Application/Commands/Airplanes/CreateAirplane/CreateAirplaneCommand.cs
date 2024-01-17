using MediatR;

namespace Kira.Flight.Application.Commands.Airplanes.CreateAirplane;

public class CreateAirplaneCommand : IRequest<Guid>
{
    public string Name { get; set; } = null!;
    public string Model { get; set; } = null!;
}