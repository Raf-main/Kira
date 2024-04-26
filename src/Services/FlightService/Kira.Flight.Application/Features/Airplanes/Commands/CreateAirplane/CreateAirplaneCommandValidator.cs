using FluentValidation;

namespace Kira.Flight.Application.Features.Airplanes.Commands.CreateAirplane;

public class CreateAirplaneCommandValidator : AbstractValidator<CreateAirplaneCommand>
{
    public CreateAirplaneCommandValidator()
    {
        RuleFor(p => p.Model)
            .NotEmpty()
            .WithMessage("Aircraft model cannot be empty")
            .MaximumLength(32)
            .WithMessage("Airplane model length should be less than 32");

        RuleFor(p => p.Name)
            .NotEmpty()
            .WithMessage("Aircraft name cannot be empty")
            .MaximumLength(32)
            .WithMessage("Airplane name length should be less than 32");
    }
}
