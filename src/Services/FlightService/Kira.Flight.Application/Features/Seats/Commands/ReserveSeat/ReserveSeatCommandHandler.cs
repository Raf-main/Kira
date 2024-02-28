using Kira.Flight.Domain.Entities;
using Light.Infrastructure.Extensions.Repositories;
using MediatR;

namespace Kira.Flight.Application.Features.Seats.Commands.ReserveSeat
{
    public class ReserveSeatCommandHandler : IRequestHandler<ReserveSeatCommand, Unit>
    {
        private readonly IAsyncGenericRepository<Seat, Guid> _repository;

        public ReserveSeatCommandHandler(IAsyncGenericRepository<Seat, Guid> repository)
        {
            _repository = repository;
        }

        public async Task<Unit> Handle(ReserveSeatCommand request, CancellationToken cancellationToken)
        {
            var entity = await _repository.GetByKeyAsync(request.SeatId, cancellationToken);

            if (entity == null)
            {
                throw new NullReferenceException(); // временно
            }

            entity.ReserveSeat();
            await _repository.UpdateAsync(entity, cancellationToken);

            return Unit.Value;
        }
    }
}
