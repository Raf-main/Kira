using Kira.Flight.Infrastructure.EfCore.Contexts;
using Light.Infrastructure.EfCore.Repositories;
using Light.Infrastructure.Extensions.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Kira.Flight.Extensions;

public static class InfrastructureExtensions
{
    public static void AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddDbContext<FlightWriteDbContext>(options =>
        {
            options.UseNpgsql(configuration.GetConnectionString("FlightWrite"),
                sqlOptions =>
                {
                    sqlOptions.EnableRetryOnFailure(3, TimeSpan.FromSeconds(3), null);
                });
        });

        services.AddScoped(typeof(IAsyncWriteRepository<,>), typeof(WriteEfRepository<,>));
        services.AddScoped(typeof(IAsyncReadRepository<,>), typeof(ReadEfRepository<,>));
        services.AddScoped(typeof(IAsyncGenericRepository<,>), typeof(GenericEfRepository<,>));
    }
}