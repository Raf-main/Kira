using Microsoft.AspNetCore.Http;

namespace Kira.Utils.Shared.Cookie;

public class CookieService(IHttpContextAccessor httpContextAccessor) : ICookieService
{
    private readonly HttpContext _httpContext = httpContextAccessor.HttpContext;

    public void SetResponseCookie(string key,
        string value,
        DateTime expirationDate,
        bool httpOnly = false,
        SameSiteMode sameSite = SameSiteMode.None
    )
    {
        var cookieOptions = new CookieOptions { HttpOnly = httpOnly, SameSite = sameSite, Expires = expirationDate };

        _httpContext.Response.Cookies.Append(key, value, cookieOptions);
    }

    public bool TryGetRequestCookie(string key, out string? value)
    {
        return _httpContext.Request.Cookies.TryGetValue(key, out value);
    }
}