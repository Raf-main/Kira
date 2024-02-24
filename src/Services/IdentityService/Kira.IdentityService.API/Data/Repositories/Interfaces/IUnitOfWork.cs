namespace Kira.IdentityService.API.Data.Repositories.Interfaces
{
    public interface IUnitOfWork
    {
        IRefreshTokenRepository RefreshTokens { get; }
        Task SaveChangesAsync();
    }
}
