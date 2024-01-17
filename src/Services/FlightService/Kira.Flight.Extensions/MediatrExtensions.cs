using Kira.Flight.Application.Behaviors;
using Microsoft.Extensions.DependencyInjection;

namespace Kira.Flight.Extensions;

public static class MediatrExtensions
{
    public static MediatRServiceConfiguration UseCustomMediatrConfiguration(
        this MediatRServiceConfiguration mediatrConfiguration
    )
    {
        mediatrConfiguration.AddOpenBehavior(typeof(ValidationBehavior<,>));

        return mediatrConfiguration;
    }
}