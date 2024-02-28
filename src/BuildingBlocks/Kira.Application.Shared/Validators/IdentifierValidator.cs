using FluentValidation;

namespace Kira.Application.Shared.Validators
{
    public class IdentifierValidator<T> : AbstractValidator<T>, IIdentifierValidator<T>
    {
        public IdentifierValidator()
        {
            RuleFor(x => x).NotEmpty().WithMessage("Id can't be empty");
        }
    }
}
