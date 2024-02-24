using System.ComponentModel.DataAnnotations;

namespace Kira.IdentityService.API.ViewModels.Request
{
    public record RegistrationRequest(
        [Required(ErrorMessage = "UserName is required")]
        [MinLength(4, ErrorMessage = "Min userName length is 4 symbols")]
        [MaxLength(50, ErrorMessage = "Max userName length is 50 symbols")]
        string UserName,
        [Required(ErrorMessage = "Email is required")]
        [EmailAddress(ErrorMessage = "Email is not valid")]
        string Email,
        [Required(ErrorMessage = "Password is required")]
        [MinLength(6, ErrorMessage = "Min password length is 6 symbols")]
        [MaxLength(12, ErrorMessage = "Max password length is 12 symbols")]
        string Password
    );
}
