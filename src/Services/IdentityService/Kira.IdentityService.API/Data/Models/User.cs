using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations.Schema;

namespace Kira.IdentityService.API.Data.Models;

public class User : IdentityUser
{
    [InverseProperty(nameof(RefreshToken.User))]
    public virtual ICollection<RefreshToken> RefreshTokens { get; set; } = new HashSet<RefreshToken>();
}