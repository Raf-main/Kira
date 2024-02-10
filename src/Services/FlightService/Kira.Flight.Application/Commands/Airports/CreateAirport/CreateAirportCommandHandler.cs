using Kira.Flight.Domain.Entities;
using Light.Infrastructure.Extensions.Repositories;
using MediatR;

namespace Kira.Flight.Application.Commands.Airports.CreateAirport;

public class CreateAirportCommandHandler(IAsyncWriteRepository<Airport, Guid> writeRepository)
    : IRequestHandler<CreateAirportCommand, Guid>
{
    public async Task<Guid> Handle(CreateAirportCommand request, CancellationToken cancellationToken)
    {
        var airport = Airport.Create(request.Name);
        await writeRepository.AddAsync(airport, cancellationToken);

        return airport.Id;
    }
}