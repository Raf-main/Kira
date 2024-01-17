using Kira.Flight.Domain.Entities;
using Light.Infrastructure.Extensions.Repositories;
using MediatR;

namespace Kira.Flight.Application.Commands.Airports.CreateAirport;

public class CreateAirportCommandHandler : IRequestHandler<CreateAirportCommand, Guid>
{
    private readonly IAsyncWriteRepository<Airport, Guid> _writeRepository;

    public CreateAirportCommandHandler(IAsyncWriteRepository<Airport, Guid> writeRepository)
    {
        _writeRepository = writeRepository;
    }

    public async Task<Guid> Handle(CreateAirportCommand request, CancellationToken cancellationToken)
    {
        var airport = Airport.Create(request.Name);
        await _writeRepository.AddAsync(airport);

        return airport.Id;
    }
}