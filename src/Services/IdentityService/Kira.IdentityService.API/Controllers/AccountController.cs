using Kira.IdentityService.API.Services.Interfaces;
using Kira.IdentityService.API.ViewModels.Request;
using Kira.Utils.Shared.Cookie;

using Microsoft.AspNetCore.Mvc;

namespace Kira.IdentityService.API.Controllers;

[Route("api/[controller]/[action]")]
[ApiController]
public class AccountController(IAccountService accountService, ICookieService cookieService) : ControllerBase
{
    private const string RefreshTokenCookieKey = "RefreshToken";

    [HttpPost]
    [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(LoginRequest))]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<IActionResult> Login([FromBody] LoginRequest loginRequest)
    {
        if (!ModelState.IsValid)
        {
            return UnprocessableEntity(ModelState);
        }

        var loginResponse = await accountService.LoginAsync(loginRequest);

        cookieService.SetResponseCookie(RefreshTokenCookieKey, loginResponse.RefreshToken,
            loginResponse.RefreshTokenExpirationTime, true, SameSiteMode.Strict);

        return Ok(new { loginResponse.AccessToken, loginResponse.User });
    }

    [HttpPost]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<IActionResult> Register([FromBody] RegistrationRequest registrationRequest)
    {
        if (!ModelState.IsValid)
        {
            return UnprocessableEntity(ModelState);
        }

        await accountService.RegisterAsync(registrationRequest);

        return Ok();
    }

    [HttpPost]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status401Unauthorized)]
    public async Task<IActionResult> RefreshAccessToken()
    {
        if (!cookieService.TryGetRequestCookie(RefreshTokenCookieKey, out var refreshToken) ||
            string.IsNullOrEmpty(refreshToken))
        {
            return Unauthorized("Request doesn't contain refresh token");
        }

        var refreshTokenRequest = new RefreshTokenRequest(refreshToken);

        var refreshTokenResponse = await accountService.RefreshTokenAsync(refreshTokenRequest);

        cookieService.SetResponseCookie(RefreshTokenCookieKey, refreshTokenResponse.RefreshToken,
            refreshTokenResponse.RefreshTokenExpirationTime, true, SameSiteMode.Strict);

        return Ok(new { refreshTokenResponse.AccessToken, refreshTokenResponse.User });
    }
}
