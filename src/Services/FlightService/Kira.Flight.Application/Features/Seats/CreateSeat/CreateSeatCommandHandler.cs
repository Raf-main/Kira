using Kira.Flight.Domain.Entities;
using Kira.Flight.Infrastructure.Interfaces.Repositories;
using MediatR;

namespace Kira.Flight.Application.Features.Seats.CreateSeat;

public class CreateSeatCommandHandler : IRequestHandler<CreateSeatCommand, Guid>
{
    private readonly ISeatWriteRepository _writeRepository;

    public CreateSeatCommandHandler(ISeatWriteRepository writeRepository)
    {
        _writeRepository = writeRepository;
    }

    public async Task<Guid> Handle(CreateSeatCommand request, CancellationToken cancellationToken)
    {
        var airplane = Seat.Create(request.SeatNumber, request.FlightId);
        await _writeRepository.AddAsync(airplane);

        return airplane.Id;
    }
}