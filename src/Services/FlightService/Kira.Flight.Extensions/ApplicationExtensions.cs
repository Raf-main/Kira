using System.Reflection;
using FluentValidation;
using Kira.Application.Shared.Validators;
using Kira.Flight.Application.Behaviors;
using Kira.Flight.Application.Features.Airplanes.Commands.CreateAirplane;
using Kira.Flight.Application.Features.Airplanes.Mappings;
using Kira.Utils.Shared.Serializers;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Kira.Flight.Extensions;

public static class ApplicationExtensions
{
    public static void AddApplicationServices(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddMediatR(mediatrConfiguration =>
        {
            mediatrConfiguration.RegisterServicesFromAssembly(Assembly.GetAssembly(typeof(CreateAirplaneCommand)) ??
                                                              throw new Exception());

            mediatrConfiguration.AddOpenBehavior(typeof(LoggingBehavior<,>));
            mediatrConfiguration.AddOpenBehavior(typeof(ValidationBehavior<,>));

            //mediatrConfiguration.AddOpenBehavior(typeof(CachingBehavior<,>));
        });

        services.AddValidatorsFromAssemblyContaining(typeof(CreateAirplaneCommandValidator));
        services.AddScoped<IValidator<Guid>, IdentifierValidator<Guid>>();
        services.AddScoped<IIdentifierValidator<Guid>, IdentifierValidator<Guid>>();
        services.AddAutoMapper(Assembly.GetAssembly(typeof(AirplaneMapper)));
        services.AddSingleton<ISerializer, JsonSerializer>();
    }
}
