using MediatR;
using Microsoft.Extensions.DependencyInjection;
using Kira.Flight.Application.Behaviors;
namespace Kira.Flight.Extensions;

public static class MediatrExtensions
{
    public static MediatRServiceConfiguration UseCustomMediatrConfiguration(this MediatRServiceConfiguration mediatrConfiguration)
    {
        mediatrConfiguration.AddOpenBehavior(typeof(ValidationBehavior<,>));

        return mediatrConfiguration;
    }
}