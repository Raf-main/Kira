using FluentValidation;

namespace Kira.Flight.Application.Features.Flights.Commands.CreateFlight;

public class CreateFlightCommandValidator : AbstractValidator<CreateFlightCommand>
{
    public CreateFlightCommandValidator()
    {
        RuleFor(p => p.DateTime.ToUniversalTime())
            .GreaterThan(DateTime.UtcNow)
            .WithMessage("arriving UTC DateTime is less than current UTC time");

        RuleFor(p => p.FromAirportId).NotEmpty().WithMessage("FromAirportId cannot be empty");

        RuleFor(p => p.ToAirportId).NotEmpty().WithMessage("ToAirportId cannot be empty");

        RuleFor(p => p.PlaneId).NotEmpty().WithMessage("AirplaneId cannot be empty");

        RuleFor(p => p.Price).GreaterThan(0).WithMessage("Price should be more than 0");
    }
}
