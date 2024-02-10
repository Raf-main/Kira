using Kira.Security.Shared.Jwt.Options;
using Kira.Utils.Shared.Time;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;

namespace Kira.Security.Shared.Jwt.Services;

public class JwtService(IOptions<JwtOptions> jwtOptions, IDateTimeProvider dateTimeProvider) : IJwtService
{
    private readonly JwtOptions _jwtOptions = jwtOptions.Value;

    public string GenerateAccessToken(IEnumerable<Claim> claims, DateTime? expirationTime = null)
    {
        var secretKey = _jwtOptions.GetSymmetricSecurityKey();
        var securityAlgorithm = _jwtOptions.Algorithm ?? SecurityAlgorithms.HmacSha256;
        var signinCredentials = new SigningCredentials(secretKey, securityAlgorithm);
        var expires = expirationTime ?? dateTimeProvider.UtcNow().AddMinutes(_jwtOptions.TokenExpirationTimeInMinutes);

        var tokenOptions = new JwtSecurityToken(null, null, claims, expires, signingCredentials: signinCredentials);

        var token = new JwtSecurityTokenHandler().WriteToken(tokenOptions);

        return token;
    }
}