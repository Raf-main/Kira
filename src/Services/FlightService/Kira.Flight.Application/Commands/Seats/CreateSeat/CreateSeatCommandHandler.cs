using Kira.Flight.Domain.Entities;
using Light.Infrastructure.Extensions.Repositories;
using MediatR;

namespace Kira.Flight.Application.Commands.Seats.CreateSeat;

public class CreateSeatCommandHandler : IRequestHandler<CreateSeatCommand, Guid>
{
    private readonly IAsyncWriteRepository<Seat, Guid> _writeRepository;

    public CreateSeatCommandHandler(IAsyncWriteRepository<Seat, Guid> writeRepository)
    {
        _writeRepository = writeRepository;
    }

    public async Task<Guid> Handle(CreateSeatCommand request, CancellationToken cancellationToken)
    {
        var airplane = Seat.Create(request.SeatNumber, request.FlightId);
        await _writeRepository.AddAsync(airplane, cancellationToken);

        return airplane.Id;
    }
}