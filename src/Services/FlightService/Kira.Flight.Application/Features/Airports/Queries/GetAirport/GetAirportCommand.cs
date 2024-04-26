using Kira.Application.Shared.Queries;
using Kira.Flight.Application.Features.Airports.Dto;
using MediatR;

namespace Kira.Flight.Application.Features.Airports.Queries.GetAirport;

public record GetAirportCommand(Guid Id) : IRequest<AirportDto>, ICacheableQuery<GetAirportCommand>
{
    public string GetCacheKey()
    {
        throw new NotImplementedException();
    }
}
