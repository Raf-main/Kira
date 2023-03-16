using Kira.Flight.Infrastructure.Interfaces.Repositories;
using MediatR;

namespace Kira.Flight.Application.Features.Flights.CreateFlight;

public class CreateFlightCommandHandler : IRequestHandler<CreateFlightCommand, Guid>
{
    private readonly IFlightWriteRepository _writeRepository;

    public CreateFlightCommandHandler(IFlightWriteRepository writeRepository)
    {
        _writeRepository = writeRepository;
    }
    public async Task<Guid> Handle(CreateFlightCommand request, CancellationToken cancellationToken)
    {
        var flight = Domain.Entities.Flight.Create(
            request.PlaneId,
            request.FromAirportId,
            request.ToAirportId,
            request.Price,
            request.DateTime
        );

        await _writeRepository.AddAsync(flight);

        return flight.Id;
    }
}