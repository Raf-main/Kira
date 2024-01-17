using Light.Infrastructure.Extensions.Repositories;
using MediatR;

namespace Kira.Flight.Application.Commands.Flights.CreateFlight;

public class CreateFlightCommandHandler : IRequestHandler<CreateFlightCommand, Guid>
{
    private readonly IAsyncWriteRepository<Domain.Entities.Flight, Guid> _writeRepository;

    public CreateFlightCommandHandler(IAsyncWriteRepository<Domain.Entities.Flight, Guid> writeRepository)
    {
        _writeRepository = writeRepository;
    }

    public async Task<Guid> Handle(CreateFlightCommand request, CancellationToken cancellationToken)
    {
        var flight = Domain.Entities.Flight.Create(request.PlaneId, request.FromAirportId, request.ToAirportId,
            request.Price, request.DateTime);

        await _writeRepository.AddAsync(flight, cancellationToken);

        return flight.Id;
    }
}