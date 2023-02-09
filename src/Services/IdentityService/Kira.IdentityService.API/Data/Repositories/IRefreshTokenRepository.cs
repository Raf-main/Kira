using Kira.IdentityService.API.Data.Models;
using Kira.Infrastructure.Shared.Repositories;

namespace Kira.IdentityService.API.Data.Repositories;

public interface IRefreshTokenRepository : IAsyncReadRepository<RefreshToken, int>, IAsyncWriteRepository<RefreshToken>
{
    Task<RefreshToken?> GetByTokenAsync(string token);
}