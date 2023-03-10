using System.Runtime.Serialization;

namespace Kira.IdentityService.API.Exceptions;

public class ValidationException : Exception
{
    public IEnumerable<string> ValidationErrors { get; set; } = new List<string>();

    public ValidationException() { }

    public ValidationException(string message) : base(message) { }

    public ValidationException(string message, IEnumerable<string> validationErrors) : base(message)
    {
        ValidationErrors = validationErrors;
    }

    public ValidationException(string message,
        IEnumerable<string> validationErrors,
        Exception innerException) : base(message, innerException)
    {
        ValidationErrors = validationErrors;
    }

    protected ValidationException(SerializationInfo info, StreamingContext context) : base(info, context) { }
}