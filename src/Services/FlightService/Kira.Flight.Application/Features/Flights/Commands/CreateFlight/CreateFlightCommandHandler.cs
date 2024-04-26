using Kira.Flight.Infrastructure.Interfaces;

using MediatR;

namespace Kira.Flight.Application.Features.Flights.Commands.CreateFlight;

public class CreateFlightCommandHandler : IRequestHandler<CreateFlightCommand, Guid>
{
    private readonly IUnitOfWork _unitOfWork;

    public CreateFlightCommandHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<Guid> Handle(CreateFlightCommand request, CancellationToken cancellationToken)
    {
        var flight = Domain.Entities.Flight.Create(request.PlaneId, request.FromAirportId, request.ToAirportId,
            request.Price, request.DateTime);

        await _unitOfWork.FlightWriteRepository.AddAsync(flight, cancellationToken);
        await _unitOfWork.SaveChangesAsync(cancellationToken);

        return flight.Id;
    }
}
