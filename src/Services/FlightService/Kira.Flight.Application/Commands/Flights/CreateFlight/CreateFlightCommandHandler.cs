using Light.Infrastructure.Extensions.Repositories;
using MediatR;

namespace Kira.Flight.Application.Commands.Flights.CreateFlight;

public class CreateFlightCommandHandler(IAsyncWriteRepository<Domain.Entities.Flight, Guid> writeRepository)
    : IRequestHandler<CreateFlightCommand, Guid>
{
    public async Task<Guid> Handle(CreateFlightCommand request, CancellationToken cancellationToken)
    {
        var flight = Domain.Entities.Flight.Create(request.PlaneId, request.FromAirportId, request.ToAirportId,
            request.Price, request.DateTime);

        await writeRepository.AddAsync(flight, cancellationToken);

        return flight.Id;
    }
}