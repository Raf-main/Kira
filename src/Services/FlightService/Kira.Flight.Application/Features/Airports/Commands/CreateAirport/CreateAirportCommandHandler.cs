using Kira.Flight.Domain.Entities;
using Light.Infrastructure.Extensions.Repositories;
using MediatR;

namespace Kira.Flight.Application.Features.Airports.Commands.CreateAirport
{
    public class CreateAirportCommandHandler : IRequestHandler<CreateAirportCommand, Guid>
    {
        private readonly IAsyncGenericRepository<Airport, Guid> _airportRepository;

        public CreateAirportCommandHandler(IAsyncGenericRepository<Airport, Guid> airportRepository)
        {
            _airportRepository = airportRepository;
        }

        public async Task<Guid> Handle(CreateAirportCommand request, CancellationToken cancellationToken)
        {
            var airport = Airport.Create(request.Name);
            await _airportRepository.AddAsync(airport, cancellationToken);

            return airport.Id;
        }
    }
}
