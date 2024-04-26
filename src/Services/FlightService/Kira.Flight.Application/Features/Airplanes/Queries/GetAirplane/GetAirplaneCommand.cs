using Kira.Application.Shared.Queries;
using Kira.Flight.Application.Features.Airplanes.Dto;
using MediatR;

namespace Kira.Flight.Application.Features.Airplanes.Queries.GetAirplane;

public record GetAirplaneCommand(Guid Id) : IRequest<AirplaneDto>, ICacheableQuery<GetAirplaneCommand>
{
    public string GetCacheKey()
    {
        throw new NotImplementedException();
    }
}
