using FluentValidation;

namespace Kira.Flight.Application.Commands.Flights.CreateFlight;

public class CreateFlightCommandValidator : AbstractValidator<CreateFlightCommand>
{
    public CreateFlightCommandValidator()
    {
        RuleFor(p => p.DateTime.ToUniversalTime())
            .GreaterThan(DateTime.UtcNow)
            .WithMessage("arriving UTC DateTime is less than current UTC time");

        RuleFor(p => p.FromAirportId).NotEmpty().WithMessage("FromAirportId must not be empty");

        RuleFor(p => p.ToAirportId).NotEmpty().WithMessage("ToAirportId must not be empty");

        RuleFor(p => p.PlaneId).NotEmpty().WithMessage("AirplaneId must not be empty");

        RuleFor(p => p.Price).GreaterThan(0).WithMessage("Price must be greater than 0");
    }
}