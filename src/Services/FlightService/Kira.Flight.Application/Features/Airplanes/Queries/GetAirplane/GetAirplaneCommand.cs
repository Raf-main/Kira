using Kira.Flight.Application.Features.Airplanes.Dto;
using MediatR;

namespace Kira.Flight.Application.Features.Airplanes.Queries.GetAirplane
{
    public record GetAirplaneCommand : IRequest<AirplaneDto>
    {
        public GetAirplaneCommand(Guid Id)
        {
            this.Id = Id;
        }

        public Guid Id { get; init; }

        public void Deconstruct(out Guid Id)
        {
            Id = this.Id;
        }
    }
}
