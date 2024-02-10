namespace Kira.IdentityService.API.Data.Services.Interfaces;

public interface IDatabaseMigrationApplier
{
    void ApplyMigrations();
}