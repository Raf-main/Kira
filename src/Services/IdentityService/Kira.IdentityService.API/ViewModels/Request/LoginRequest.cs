using System.ComponentModel.DataAnnotations;

namespace Kira.IdentityService.API.ViewModels.Request;

public record LoginRequest(
    [Required(ErrorMessage = "Email is required")]
    [EmailAddress(ErrorMessage = "Email is not valid")] 
    string Email, 
    [Required(ErrorMessage = "Password is required")]
    [MinLength(6, ErrorMessage = "Min password length is 6 symbols")]
    [MaxLength(12, ErrorMessage = "Max password length is 12 symbols")]
    string Password
);