using FluentValidation;

namespace Kira.Flight.Application.Features.Airplanes.Queries.GetAirplane
{
    public class GetAirplaneCommandValidator : AbstractValidator<GetAirplaneCommand>
    {
        public GetAirplaneCommandValidator(IValidator<Guid> identifierValidator)
        {
            RuleFor(x => x.Id).SetValidator(identifierValidator);
        }
    }
}
