using Kira.IdentityService.API.ViewModels.Request;
using Kira.IdentityService.API.ViewModels.Response;

namespace Kira.IdentityService.API.Services;

public interface IAccountService
{
    Task<LoginResponse> LoginAsync(LoginRequest loginRequest);
    Task RegisterAsync(RegistrationRequest registrationRequest);
    Task<RefreshTokenResponse> RefreshTokenAsync(RefreshTokenRequest refreshRequest);
}