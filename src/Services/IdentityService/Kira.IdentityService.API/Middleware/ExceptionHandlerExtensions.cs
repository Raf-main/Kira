﻿namespace Kira.IdentityService.API.Middleware
{
    public static class ExceptionHandlerExtensions
    {
        public static void UseCustomExceptionHandler(this IApplicationBuilder app)
        {
            app.UseMiddleware<ExceptionHandlerMiddleware>();
        }
    }
}
