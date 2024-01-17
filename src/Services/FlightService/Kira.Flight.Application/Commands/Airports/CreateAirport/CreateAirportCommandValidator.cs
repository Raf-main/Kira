using FluentValidation;

namespace Kira.Flight.Application.Commands.Airports.CreateAirport;

public class CreateAirportCommandValidator : AbstractValidator<CreateAirportCommand>
{
    public CreateAirportCommandValidator()
    {
        RuleFor(p => p.Name).NotEmpty().WithMessage("FromAirportId must not be empty");
    }
}