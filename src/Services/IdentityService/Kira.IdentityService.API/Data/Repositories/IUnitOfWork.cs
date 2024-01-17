namespace Kira.IdentityService.API.Data.Repositories;

public interface IUnitOfWork
{
    IRefreshTokenRepository RefreshTokens { get; }
    Task SaveChangesAsync();
}