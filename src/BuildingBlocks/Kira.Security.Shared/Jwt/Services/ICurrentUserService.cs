using System.Security.Claims;

namespace Kira.Security.Shared.Jwt.Services
{
    public interface ICurrentUserService
    {
        ClaimsPrincipal GetUser();
        string GetId();
        bool IsAuthenticated();
        string GetUserClaim(string claimKey);
    }
}
