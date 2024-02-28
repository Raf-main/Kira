using FluentValidation;

namespace Kira.Flight.Application.Features.Seats.Commands.CreateSeat
{
    public class CreateSeatCommandValidator : AbstractValidator<CreateSeatCommand>
    {
        public CreateSeatCommandValidator()
        {
            RuleFor(p => p.SeatNumber).NotEmpty().WithMessage("SeatNumber cannot be empty");

            RuleFor(p => p.FlightId).NotEmpty().WithMessage("FlightId cannot be empty");
        }
    }
}
