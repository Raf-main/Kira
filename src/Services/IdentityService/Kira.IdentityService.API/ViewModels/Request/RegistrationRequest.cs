namespace Kira.IdentityService.API.ViewModels.Request;

public class RegistrationRequest
{
    public string UserName { get; set; } = null!;
    public string Email { get; set; } = null!;
    public string Password { get; set; } = null!;
}