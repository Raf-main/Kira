using Kira.Flight.Domain.Entities;
using Kira.Flight.Infrastructure.Interfaces;
using Light.Infrastructure.Extensions.Repositories;
using MediatR;

namespace Kira.Flight.Application.Features.Seats.Commands.ReserveSeat;

public class ReserveSeatCommandHandler : IRequestHandler<ReserveSeatCommand, Unit>
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IAsyncReadRepository<Seat, Guid> _seatReadRepository;

    public ReserveSeatCommandHandler(IUnitOfWork unitOfWork, IAsyncReadRepository<Seat, Guid> seatReadRepository)
    {
        _unitOfWork = unitOfWork;
        _seatReadRepository = seatReadRepository;
    }

    public async Task<Unit> Handle(ReserveSeatCommand request, CancellationToken cancellationToken)
    {
        var entity = await _seatReadRepository.GetByKeyAsync(request.SeatId, cancellationToken);

        if (entity == null)
        {
            throw new NullReferenceException(); // временно
        }

        entity.ReserveSeat();
        await _unitOfWork.SeatWriteRepository.UpdateAsync(entity, cancellationToken);
        await _unitOfWork.SaveChangesAsync(cancellationToken);

        return Unit.Value;
    }
}
