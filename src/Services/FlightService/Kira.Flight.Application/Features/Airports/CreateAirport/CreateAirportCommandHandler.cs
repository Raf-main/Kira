using Kira.Flight.Domain.Entities;
using Kira.Flight.Infrastructure.Interfaces.Repositories;
using MediatR;

namespace Kira.Flight.Application.Features.Airports.CreateAirport;

public class CreateAirportCommandHandler : IRequestHandler<CreateAirportCommand, Guid>
{
    private readonly IAirportWriteRepository _writeRepository;

    public CreateAirportCommandHandler(IAirportWriteRepository writeRepository)
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