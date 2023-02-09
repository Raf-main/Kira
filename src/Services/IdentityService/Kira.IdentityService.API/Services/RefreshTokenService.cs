using Kira.IdentityService.API.Data.Models;
using Kira.Security.Shared.Jwt.Options;
using Kira.Utils.Shared.Time;
using Microsoft.Extensions.Options;

namespace Kira.IdentityService.API.Services;

public class RefreshTokenService : IRefreshTokenService
{
    private readonly IDateTimeProvider _dateTimeProvider;
    private readonly JwtOptions _options;

    public RefreshTokenService(IDateTimeProvider dateTimeProvider, IOptions<JwtOptions> options)
    {
        _dateTimeProvider = dateTimeProvider;
        _options = options.Value;
    }

    public RefreshToken GenerateRefreshToken(string userId, DateTime? expirationTime = null)
    {
        var expired = expirationTime ?? _dateTimeProvider.UtcNow().AddHours(_options.RefreshTokenExpirationTimeInHours);

        return new RefreshToken
        {
            ExpirationTime = expired,
            Token = Guid.NewGuid().ToString(),
            UserId = userId
        };
    }
}