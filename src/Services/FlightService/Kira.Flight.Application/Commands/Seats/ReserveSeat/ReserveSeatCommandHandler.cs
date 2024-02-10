using Kira.Flight.Domain.Entities;
using Light.Infrastructure.Extensions.Repositories;
using MediatR;

namespace Kira.Flight.Application.Commands.Seats.ReserveSeat;

public class ReserveSeatCommandHandler(IAsyncGenericRepository<Seat, Guid> repository)
    : IRequestHandler<ReserveSeatCommand, Unit>
{
    public async Task<Unit> Handle(ReserveSeatCommand request, CancellationToken cancellationToken)
    {
        var entity = await repository.GetByKeyAsync(request.SeatId, cancellationToken);

        if (entity == null)
        {
            throw new NullReferenceException(); // временно
        }

        entity.ReserveSeat();
        await repository.UpdateAsync(entity, cancellationToken);

        return Unit.Value;
    }
}