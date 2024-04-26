using System.Security.Claims;
using Microsoft.AspNetCore.Http;

namespace Kira.Security.Shared.Jwt.Services;

public class CurrentUserService(IHttpContextAccessor contextAccessor) : ICurrentUserService
{
    private readonly HttpContext _httpContext =
        contextAccessor.HttpContext ?? throw new ArgumentNullException(nameof(contextAccessor));

    public ClaimsPrincipal GetUser()
    {
        return _httpContext.User;
    }

    public string GetId()
    {
        return GetUserClaim(ClaimTypes.NameIdentifier);
    }

    public bool IsAuthenticated()
    {
        var isAuthenticated = _httpContext.User.Identity?.IsAuthenticated;

        return isAuthenticated.HasValue && isAuthenticated.Value;
    }

    public string GetUserClaim(string claimKey)
    {
        return _httpContext.User.Claims.First(claim => claim.Type == claimKey).ToString();
    }
}
