using Microsoft.IdentityModel.Tokens;
using System.Text;

namespace Kira.Security.Shared.Jwt.Options;

public class JwtOptions
{
    public const string OptionsKey = "JwtOptions";
    public string? Algorithm { get; set; }
    public string SecretKey { get; set; } = null!;
    public bool ValidateIssuer { get; set; }
    public bool ValidateAudience { get; set; }
    public bool RequireExpirationTime { get; set; }
    public int TokenExpirationTimeInMinutes { get; set; }
    public int RefreshTokenExpirationTimeInHours { get; set; }
    public IEnumerable<string> ValidIssuers { get; set; } = null!;
    public IEnumerable<string> ValidAudiences { get; set; } = null!;

    public SymmetricSecurityKey GetSymmetricSecurityKey()
    {
        return new SymmetricSecurityKey(Encoding.UTF8.GetBytes(SecretKey));
    }
}