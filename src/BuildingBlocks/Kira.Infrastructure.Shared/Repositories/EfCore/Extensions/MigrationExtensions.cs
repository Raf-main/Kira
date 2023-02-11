using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace Kira.Infrastructure.Shared.Repositories.EfCore.Extensions;

public static class MigrationExtensions
{
    public static void AddDatabaseMigration<T>(this IServiceCollection services) where T : DbContext
    {
        using var scope = services.BuildServiceProvider().CreateScope();
        var db = scope.ServiceProvider.GetRequiredService<T>();
        db.Database.Migrate();
    }
}