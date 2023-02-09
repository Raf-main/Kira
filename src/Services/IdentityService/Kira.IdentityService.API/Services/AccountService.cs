using Kira.IdentityService.API.Data.Repositories;
using Microsoft.AspNetCore.Identity;
using Microsoft.IdentityModel.Tokens;
using System.Security.Claims;
using Kira.IdentityService.API.Data.Models;
using Kira.IdentityService.API.Exceptions;
using Kira.IdentityService.API.ViewModels.Request;
using Kira.IdentityService.API.ViewModels.Response;
using Kira.Security.Shared.Jwt.Options;
using Kira.Security.Shared.Jwt.Services;
using Microsoft.Extensions.Options;

namespace Kira.IdentityService.API.Services;

public class AccountService : IAccountService
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IJwtService _jwtService;
    private readonly IRefreshTokenService _refreshTokenService;
    private readonly UserManager<User> _userManager;

    public AccountService(IUnitOfWork unitOfWork,
        IJwtService jwtService,
        IRefreshTokenService refreshTokenService,
        UserManager<User> userManager)
    {
        _unitOfWork = unitOfWork;
        _jwtService = jwtService;
        _refreshTokenService = refreshTokenService;
        _userManager = userManager;
    }

    public async Task<LoginResponse> LoginAsync(LoginRequest loginRequest)
    {
        var user = await _userManager.FindByEmailAsync(loginRequest.Email);

        if (user == null)
        {
            throw new NotFoundException($"User with email {loginRequest.Email} was not found");
        }

        var authClaims = await GetClaimsAsync(user);

        var accessToken = _jwtService.GenerateAccessToken(authClaims);
        var refreshToken = _refreshTokenService.GenerateRefreshToken(user.Id);

        await _unitOfWork.RefreshTokens.AddAsync(refreshToken);
        await _unitOfWork.SaveChangesAsync();

        return new LoginResponse
        {
            AccessToken = accessToken,
            RefreshToken = refreshToken.Token,
            RefreshTokenExpirationTime = refreshToken.ExpirationTime
        };
    }

    public async Task RegisterAsync(RegistrationRequest registrationRequest)
    {
        var user = new User
        {
            UserName = registrationRequest.UserName,
            Email = registrationRequest.Email
        };

        var result = await _userManager.CreateAsync(user, registrationRequest.Password);

        if (!result.Succeeded)
        {
            var errors = result.Errors.Select(e => e.Description);

            throw new ValidationException(
                $"Something went wrong while creating user with email {registrationRequest.Email}",
                errors);
        }
    }

    public async Task<RefreshTokenResponse> RefreshTokenAsync(RefreshTokenRequest refreshRequest)
    {
        var refreshToken = await _unitOfWork.RefreshTokens.GetByTokenAsync(refreshRequest.RefreshToken);

        if (refreshToken == null || refreshToken.IsUsed)
        {
            throw new NotFoundException($"Refresh token was not found");
        }

        if (refreshToken.IsExpired)
        {
            throw new SecurityTokenExpiredException("Refresh token was expired");
        }

        var user = await _userManager.FindByIdAsync(refreshToken.UserId);

        if (user == null)
        {
            throw new NotFoundException($"User was not found");
        }

        var authClaims = await GetClaimsAsync(user);
        var newAccessToken = _jwtService.GenerateAccessToken(authClaims);
        var newRefreshToken = _refreshTokenService.GenerateRefreshToken(user.Id);

        refreshToken.IsUsed = true;
        await _unitOfWork.RefreshTokens.UpdateAsync(refreshToken);
        await _unitOfWork.RefreshTokens.AddAsync(newRefreshToken);
        await _unitOfWork.SaveChangesAsync();

        return new RefreshTokenResponse()
        {
            AccessToken = newAccessToken,
            RefreshToken = newRefreshToken.Token,
            RefreshTokenExpirationTime = newRefreshToken.ExpirationTime
        };
    }

    private async Task<IEnumerable<Claim>> GetClaimsAsync(User user)
    {
        var authClaims = new List<Claim>
        {
            new(ClaimTypes.Email, user.Email!),
            new(ClaimTypes.NameIdentifier, user.Id)
        };

        var userRoles = await _userManager.GetRolesAsync(user);

        if (userRoles is { Count: > 0 })
        {
            authClaims.AddRange(userRoles.Where(role => !string.IsNullOrEmpty(role))
                .Select(role => new Claim(ClaimTypes.Role, role)));
        }

        return authClaims;
    }
}