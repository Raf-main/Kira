using System.Net;
using System.Text.Json;
using Kira.IdentityService.API.Exceptions;

namespace Kira.IdentityService.API.Middleware;

public class ExceptionHandlerMiddleware(RequestDelegate next, ILogger<ExceptionHandlerMiddleware> logger)
{
    public async Task Invoke(HttpContext context)
    {
        try
        {
            await next(context);
        }
        catch (Exception error)
        {
            var response = context.Response;
            response.ContentType = "application/json";

            response.StatusCode = error switch
            {
                ValidationException => (int)HttpStatusCode.BadRequest,
                NotFoundException => (int)HttpStatusCode.NotFound,
                _ => (int)HttpStatusCode.InternalServerError
            };

            logger.LogError(error, "Middleware caught error");

            var result = JsonSerializer.Serialize(new { message = error.Message });
            await response.WriteAsync(result);
        }
    }
}
