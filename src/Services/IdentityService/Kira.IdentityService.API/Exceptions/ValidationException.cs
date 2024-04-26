namespace Kira.IdentityService.API.Exceptions;

public class ValidationException : Exception
{
    public ValidationException() { }

    public ValidationException(string message) : base(message) { }

    public ValidationException(string message, IEnumerable<string> validationErrors) : base(message)
    {
        ValidationErrors = validationErrors;
    }

    public ValidationException(string message, IEnumerable<string> validationErrors, Exception innerException) : base(
        message, innerException)
    {
        ValidationErrors = validationErrors;
    }

    public IEnumerable<string> ValidationErrors { get; } = [];

    public override string Message => string.Join(Environment.NewLine, ValidationErrors);
}
