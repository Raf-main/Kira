using Kira.Application.Shared.Queries;

namespace Kira.Flight.Application.Features.Airports.Dto;

public record AirportDto(Guid Id, string Name) : ICacheableQuery<AirportDto>
{
    public string GetCacheKey()
    {
        return $"{AirportCacheKeys.BaseKey}_{Id}";
    }
}
