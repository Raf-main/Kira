using Kira.Flight.Domain.Entities;
using Light.Infrastructure.Extensions.Repositories;
using MediatR;

namespace Kira.Flight.Application.Features.Seats.Commands.CreateSeat
{
    public class CreateSeatCommandHandler : IRequestHandler<CreateSeatCommand, Guid>
    {
        private readonly IAsyncGenericRepository<Seat, Guid> _seatRepository;

        public CreateSeatCommandHandler(IAsyncGenericRepository<Seat, Guid> seatRepository)
        {
            _seatRepository = seatRepository;
        }

        public async Task<Guid> Handle(CreateSeatCommand request, CancellationToken cancellationToken)
        {
            var airplane = Seat.Create(request.SeatNumber, request.FlightId);
            await _seatRepository.AddAsync(airplane, cancellationToken);

            return airplane.Id;
        }
    }
}
