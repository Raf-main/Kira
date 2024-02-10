namespace Kira.IdentityService.API.ViewModels.Response;

public record LoginResponse(string AccessToken,string RefreshToken, DateTime RefreshTokenExpirationTime, UserResponse User);