using Kira.Flight.Domain.Entities;
using Kira.Flight.Infrastructure.Interfaces;
using MediatR;

namespace Kira.Flight.Application.Features.Airports.Commands.CreateAirport
{
    public class CreateAirportCommandHandler : IRequestHandler<CreateAirportCommand, Guid>
    {
        private readonly IUnitOfWork _unitOfWork;

        public CreateAirportCommandHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<Guid> Handle(CreateAirportCommand request, CancellationToken cancellationToken)
        {
            var airport = Airport.Create(request.Name);
            await _unitOfWork.AirportWriteRepository.AddAsync(airport, cancellationToken);
            await _unitOfWork.SaveChangesAsync(cancellationToken);

            return airport.Id;
        }
    }
}
