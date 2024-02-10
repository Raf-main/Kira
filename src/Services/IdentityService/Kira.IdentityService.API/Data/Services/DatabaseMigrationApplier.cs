using Kira.IdentityService.API.Data.Services.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Kira.IdentityService.API.Data.Services;

public class DatabaseMigrationApplier(DbContext context) : IDatabaseMigrationApplier
{
    public void ApplyMigrations()
    {
        context.Database.Migrate();
    }
}