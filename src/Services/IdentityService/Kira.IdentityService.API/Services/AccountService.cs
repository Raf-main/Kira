using Kira.IdentityService.API.Data.Models;
using Kira.IdentityService.API.Data.Repositories;
using Kira.IdentityService.API.Exceptions;
using Kira.IdentityService.API.ViewModels.Request;
using Kira.IdentityService.API.ViewModels.Response;
using Kira.Security.Shared.Jwt.Services;
using Microsoft.AspNetCore.Identity;
using Microsoft.IdentityModel.Tokens;
using System.Security.Claims;
using LoginRequest = Kira.IdentityService.API.ViewModels.Request.LoginRequest;

namespace Kira.IdentityService.API.Services;

public class AccountService(
    IUnitOfWork unitOfWork,
    IJwtService jwtService,
    IRefreshTokenService refreshTokenService,
    UserManager<User> userManager
) : IAccountService
{
    public async Task<LoginResponse> LoginAsync(LoginRequest loginRequest)
    {
        var user = await userManager.FindByEmailAsync(loginRequest.Email);

        if (user == null)
        {
            throw new NotFoundException($"User with email {loginRequest.Email} was not found");
        }

        var authClaims = await GetClaimsAsync(user);

        var accessToken = jwtService.GenerateAccessToken(authClaims);
        var refreshToken = refreshTokenService.GenerateRefreshToken(user.Id);

        await unitOfWork.RefreshTokens.AddAsync(refreshToken);
        await unitOfWork.SaveChangesAsync();

        return new LoginResponse(accessToken, refreshToken.Token, refreshToken.ExpirationTime, GetUserResponse(user));
    }

    public async Task RegisterAsync(RegistrationRequest registrationRequest)
    {
        var user = new User { UserName = registrationRequest.UserName, Email = registrationRequest.Email };

        var result = await userManager.CreateAsync(user, registrationRequest.Password);

        if (!result.Succeeded)
        {
            var errors = result.Errors.Select(e => e.Description);

            throw new ValidationException(
                $"Something went wrong while creating user with email {registrationRequest.Email}", errors);
        }
    }

    public async Task<RefreshTokenResponse> RefreshTokenAsync(RefreshTokenRequest refreshRequest)
    {
        var refreshToken = await unitOfWork.RefreshTokens.GetByTokenAsync(refreshRequest.RefreshToken);

        if (refreshToken == null || refreshToken.IsUsed)
        {
            throw new NotFoundException("Refresh token was not found");
        }

        if (refreshToken.IsExpired)
        {
            throw new SecurityTokenExpiredException("Refresh token was expired");
        }

        var user = await userManager.FindByIdAsync(refreshToken.UserId) ?? throw new NotFoundException("User was not found");
        var authClaims = await GetClaimsAsync(user);
        var newAccessToken = jwtService.GenerateAccessToken(authClaims);
        var newRefreshToken = refreshTokenService.GenerateRefreshToken(user.Id);

        refreshToken.IsUsed = true;
        await unitOfWork.RefreshTokens.UpdateAsync(refreshToken);
        await unitOfWork.RefreshTokens.AddAsync(newRefreshToken);
        await unitOfWork.SaveChangesAsync();

        return new RefreshTokenResponse(newAccessToken, newRefreshToken.Token, newRefreshToken.ExpirationTime,
            GetUserResponse(user));
    }

    private async Task<IEnumerable<Claim>> GetClaimsAsync(User user)
    {
        var authClaims = new List<Claim>
        {
            new(ClaimTypes.Email, user.Email!), new(ClaimTypes.NameIdentifier, user.Id)
        };

        var userRoles = await userManager.GetRolesAsync(user);

        if (userRoles is { Count: > 0 })
        {
            authClaims.AddRange(userRoles.Where(role => !string.IsNullOrEmpty(role))
                .Select(role => new Claim(ClaimTypes.Role, role)));
        }

        return authClaims;
    }

    private static UserResponse GetUserResponse(User user) => new(user.Id, user.UserName, user.Email);
}