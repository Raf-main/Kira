using FluentValidation;

namespace Kira.Flight.Application.Features.Seats.Commands.ReserveSeat
{
    public class ReserveSeatCommandValidator : AbstractValidator<ReserveSeatCommand>
    {
        public ReserveSeatCommandValidator()
        {
            RuleFor(x => x.SeatId).NotEmpty().WithMessage("SeatId cannot be empty");
        }
    }
}
