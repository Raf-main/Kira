using Kira.Flight.Infrastructure.EfCore.Contexts;
using Kira.Flight.Infrastructure.EfCore.Repositories;
using Kira.Flight.Infrastructure.Interfaces.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking.Internal;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Kira.Flight.Extensions;

public static class InfrastructureExtensions
{
    public static void AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddDbContext<FlightWriteDbContext>(options =>
        {
            options.UseSqlServer(configuration.GetConnectionString("FlightWrite"),
                sqlServerOptionsAction: sqlOptions =>
                {
                    sqlOptions.EnableRetryOnFailure(
                        5,
                        TimeSpan.FromSeconds(30),
                        null);
                });
        });

        services.AddScoped<IFlightWriteRepository, FlightWriteRepository>();
        services.AddScoped<ISeatWriteRepository, SeatWriteRepository>();
        services.AddScoped<IAirportWriteRepository, AirportWriteRepository>();
        services.AddScoped<IAirplaneWriteRepository, AirplaneWriteRepository>();
    }
}