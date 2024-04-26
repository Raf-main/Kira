using FluentValidation;

namespace Kira.Flight.Application.Features.Airports.Commands.CreateAirport;

public class CreateAirportCommandValidator : AbstractValidator<CreateAirportCommand>
{
    public CreateAirportCommandValidator()
    {
        RuleFor(p => p.Name)
            .NotEmpty()
            .WithMessage("Airport name cannot be empty")
            .MaximumLength(32)
            .WithMessage("Airport name length should be less than 32");
    }
}
