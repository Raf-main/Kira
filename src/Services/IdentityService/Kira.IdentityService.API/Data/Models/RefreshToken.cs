using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

using Light.Core.Extensions.Entities;

namespace Kira.IdentityService.API.Data.Models;

public class RefreshToken : Entity<int>
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public override int Id { get; set; }

    [MaxLength(50)]
    public string Token { get; set; } = null!;

    [MaxLength(50)]
    public string UserId { get; set; } = null!;

    public bool IsUsed { get; set; }
    public bool IsExpired => ExpirationTime < DateTime.UtcNow;
    public DateTime ExpirationTime { get; set; }

    [ForeignKey(nameof(UserId))]
    [InverseProperty(nameof(Models.User.RefreshTokens))]
    public virtual User User { get; set; } = null!;
}
