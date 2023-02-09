namespace Kira.IdentityService.API.ViewModels.Response;

public class LoginResponse
{
    public string AccessToken { get; set; } = null!;
    public string RefreshToken { get; set; } = null!;
    public DateTime RefreshTokenExpirationTime { get; set; }
}