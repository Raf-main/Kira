using MediatR;

namespace Kira.Flight.Application.Features.Seats.ReserveSeat;

public class ReserveSeatCommandHandler : IRequestHandler<ReserveSeatCommand,Unit>
{
    public Task<Unit> Handle(ReserveSeatCommand request, CancellationToken cancellationToken)
    {
        
    }
}