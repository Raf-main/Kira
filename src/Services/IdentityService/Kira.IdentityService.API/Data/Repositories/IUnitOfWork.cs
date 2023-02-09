namespace Kira.IdentityService.API.Data.Repositories;

public interface IUnitOfWork
{
    Task SaveChangesAsync();
    IRefreshTokenRepository RefreshTokens { get; }
}