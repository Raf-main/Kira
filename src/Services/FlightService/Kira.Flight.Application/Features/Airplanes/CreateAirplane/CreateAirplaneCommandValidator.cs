using FluentValidation;

namespace Kira.Flight.Application.Features.Airplanes.CreateAirplane;

public class CreateAirplaneCommandValidator : AbstractValidator<CreateAirplaneCommand>
{
    public CreateAirplaneCommandValidator()
    {
        RuleFor(p => p.Model)
            .NotEmpty()
            .WithMessage("Airplane model must not be empty");

        RuleFor(p => p.Name)
            .NotEmpty()
            .WithMessage("Airplane name must not be empty");
    }
}