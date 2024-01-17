using Kira.IdentityService.API.Services;
using Kira.IdentityService.API.ViewModels.Request;
using Kira.Utils.Shared.Cookie;
using Microsoft.AspNetCore.Mvc;

namespace Kira.IdentityService.API.Controllers;

[Route("api/[controller]/[action]")]
[ApiController]
public class AccountController : ControllerBase
{
    private const string RefreshTokenCookieKey = "RefreshToken";
    private readonly IAccountService _accountService;
    private readonly ICookieService _cookieService;

    public AccountController(IAccountService accountService, ICookieService cookieService)
    {
        _accountService = accountService;
        _cookieService = cookieService;
    }

    [HttpPost]
    [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(LoginRequest))]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<IActionResult> Login([FromBody] LoginRequest loginRequest)
    {
        var loginResponse = await _accountService.LoginAsync(loginRequest);

        _cookieService.SetResponseCookie(RefreshTokenCookieKey, loginResponse.RefreshToken,
            loginResponse.RefreshTokenExpirationTime, true, SameSiteMode.Strict);

        return Ok(loginResponse.RefreshToken);
    }

    [HttpPost]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<IActionResult> Register([FromBody] RegistrationRequest registrationRequest)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState.Root.Errors.Select(e => e.ErrorMessage));
        }

        await _accountService.RegisterAsync(registrationRequest);

        return Ok();
    }

    [HttpPost]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status401Unauthorized)]
    public async Task<IActionResult> RefreshAccessToken()
    {
        if (_cookieService.TryGetRequestCookie(RefreshTokenCookieKey, out var refreshToken) ||
            string.IsNullOrEmpty(refreshToken))
        {
            return Unauthorized("Request doesn't contain refresh token");
        }

        var refreshTokenRequest = new RefreshTokenRequest { RefreshToken = refreshToken };

        var refreshTokenResponse = await _accountService.RefreshTokenAsync(refreshTokenRequest);

        _cookieService.SetResponseCookie(RefreshTokenCookieKey, refreshTokenResponse.RefreshToken,
            refreshTokenResponse.RefreshTokenExpirationTime, true, SameSiteMode.Strict);

        return Ok(refreshTokenResponse.AccessToken);
    }
}