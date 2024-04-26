using FluentValidation;

namespace Kira.Application.Shared.Validators;

public interface IIdentifierValidator<in T> : IValidator<T>;
