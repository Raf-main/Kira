using FluentValidation;

namespace Kira.Flight.Application.Commands.Seats.CreateSeat;

public class CreateSeatCommandValidator : AbstractValidator<CreateSeatCommand>
{
    public CreateSeatCommandValidator()
    {
        RuleFor(p => p.SeatNumber).NotEmpty().WithMessage("SeatNumber must not be empty");

        RuleFor(p => p.FlightId).NotEmpty().WithMessage("FlightId must not be empty");
    }
}