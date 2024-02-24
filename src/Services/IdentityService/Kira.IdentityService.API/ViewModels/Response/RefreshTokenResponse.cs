namespace Kira.IdentityService.API.ViewModels.Response
{
    public record RefreshTokenResponse(string AccessToken, string RefreshToken, DateTime RefreshTokenExpirationTime, UserResponse User);
}
