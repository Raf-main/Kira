using Light.Infrastructure.Extensions.Repositories;
using MediatR;

namespace Kira.Flight.Application.Features.Flights.CreateFlight
{
    public class CreateFlightCommandHandler : IRequestHandler<CreateFlightCommand, Guid>
    {
        private readonly IAsyncGenericRepository<Domain.Entities.Flight, Guid> _flightRepository;

        public CreateFlightCommandHandler(IAsyncGenericRepository<Domain.Entities.Flight, Guid> flightRepository)
        {
            _flightRepository = flightRepository;
        }

        public async Task<Guid> Handle(CreateFlightCommand request, CancellationToken cancellationToken)
        {
            var flight = Domain.Entities.Flight.Create(request.PlaneId, request.FromAirportId, request.ToAirportId, request.Price, request.DateTime);

            await _flightRepository.AddAsync(flight, cancellationToken);

            return flight.Id;
        }
    }
}
