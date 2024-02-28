using Kira.Flight.Application.Features.Airports.Dto;
using MediatR;

namespace Kira.Flight.Application.Features.Airports.Queries.GetAirport
{
    public record GetAirportCommand : IRequest<AirportDto>
    {
        public GetAirportCommand(Guid Id)
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
