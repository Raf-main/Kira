using Kira.IdentityService.API.Data.Models;
using Light.Infrastructure.Extensions.Repositories;

namespace Kira.IdentityService.API.Data.Repositories.Interfaces;

public interface IRefreshTokenRepository : IAsyncReadRepository<RefreshToken, int>,
    IAsyncWriteRepository<RefreshToken, int>
{
    Task<RefreshToken?> GetByTokenAsync(string token);
}
