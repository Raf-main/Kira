using Kira.Flight.Domain.Entities;
using Light.Infrastructure.Extensions.Repositories;
using MediatR;

namespace Kira.Flight.Application.Commands.Seats.CreateSeat;

public class CreateSeatCommandHandler(IAsyncWriteRepository<Seat, Guid> writeRepository)
    : IRequestHandler<CreateSeatCommand, Guid>
{
    public async Task<Guid> Handle(CreateSeatCommand request, CancellationToken cancellationToken)
    {
        var airplane = Seat.Create(request.SeatNumber, request.FlightId);
        await writeRepository.AddAsync(airplane, cancellationToken);

        return airplane.Id;
    }
}