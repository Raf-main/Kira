using FluentValidation;

namespace Kira.Flight.Application.Features.Airports.Queries.GetAirport;

public class GetAirportValidator : AbstractValidator<GetAirportCommand>
{
    public GetAirportValidator(IValidator<Guid> identifierValidator)
    {
        RuleFor(x => x.Id).SetValidator(identifierValidator);
    }
}
