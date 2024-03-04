using System.Net;
using System.Text.Json;
using FluentValidation;
using Kira.Flight.Application.Exceptions;

namespace Kira.Flight.API.Middleware
{
    public class ExceptionHandlerMiddleware(RequestDelegate next, ILogger<ExceptionHandlerMiddleware> logger)
    {
        public async Task Invoke(HttpContext context)
        {
            try
            {
                await next(context);
            }
            catch (Exception exception)
            {
                var response = context.Response;
                response.ContentType = "application/json";

                response.StatusCode = exception switch
                {
                    ValidationException => (int)HttpStatusCode.BadRequest,
                    NotFoundException => (int)HttpStatusCode.NotFound,
                    _ => (int)HttpStatusCode.InternalServerError
                };

                logger.LogError(exception, "Middleware caught error");

                string result;

                if (exception is ValidationException validationException)
                {
                    var errors = new Dictionary<string, List<string>>();

                    foreach (var failure in validationException.Errors)
                    {
                        var field = failure.PropertyName;
                        var errorMessage = failure.ErrorMessage;

                        if (!errors.TryGetValue(field, out var value))
                        {
                            value = new List<string>();
                            errors[field] = value;
                        }

                        value.Add(errorMessage);
                    }

                    result = JsonSerializer.Serialize(new { Errors = errors });
                }
                else
                {
                    result = JsonSerializer.Serialize(new { message = exception.Message });
                }

                await response.WriteAsync(result);
            }
        }
    }
}
