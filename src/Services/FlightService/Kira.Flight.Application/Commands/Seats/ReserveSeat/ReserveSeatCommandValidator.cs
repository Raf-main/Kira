using FluentValidation;

namespace Kira.Flight.Application.Commands.Seats.ReserveSeat;

public class ReserveSeatCommandValidator : AbstractValidator<ReserveSeatCommand>
{
    public ReserveSeatCommandValidator()
    {
        RuleFor(x => x.SeatId).NotEmpty().WithMessage("SeatId must not be empty");
    }
}