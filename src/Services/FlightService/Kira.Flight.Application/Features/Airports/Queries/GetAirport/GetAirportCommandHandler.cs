using AutoMapper;

using Kira.Flight.Application.Features.Airports.Dto;
using Kira.Flight.Domain.Entities;

using Light.Infrastructure.Extensions.Repositories;

using MediatR;

namespace Kira.Flight.Application.Features.Airports.Queries.GetAirport;

public class GetAirportCommandHandler : IRequestHandler<GetAirportCommand, AirportDto>
{
    private readonly IMapper _mapper;
    private readonly IAsyncGenericRepository<Airport, Guid> _airportRepository;

    public GetAirportCommandHandler(IAsyncGenericRepository<Airport, Guid> airportRepository, IMapper mapper)
    {
        _airportRepository = airportRepository;
        _mapper = mapper;
    }

    public async Task<AirportDto> Handle(GetAirportCommand request, CancellationToken cancellationToken)
    {
        var airport = await _airportRepository.GetByKeyAsync(request.Id, cancellationToken);

        return _mapper.Map<AirportDto>(airport);
    }
}
