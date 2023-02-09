using Kira.IdentityService.API.Data.Models;

namespace Kira.IdentityService.API.Services;

public interface IRefreshTokenService
{
    RefreshToken GenerateRefreshToken(string userId, DateTime? expirationTime = null);
}