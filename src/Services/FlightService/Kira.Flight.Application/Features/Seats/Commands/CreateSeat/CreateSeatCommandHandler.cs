using Kira.Flight.Domain.Entities;
using Kira.Flight.Infrastructure.Interfaces;
using MediatR;

namespace Kira.Flight.Application.Features.Seats.Commands.CreateSeat;

public class CreateSeatCommandHandler : IRequestHandler<CreateSeatCommand, Guid>
{
    private readonly IUnitOfWork _unitOfWork;

    public CreateSeatCommandHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<Guid> Handle(CreateSeatCommand request, CancellationToken cancellationToken)
    {
        var airplane = Seat.Create(request.SeatNumber, request.FlightId);
        await _unitOfWork.SeatWriteRepository.AddAsync(airplane, cancellationToken);
        await _unitOfWork.SaveChangesAsync(cancellationToken);

        return airplane.Id;
    }
}
