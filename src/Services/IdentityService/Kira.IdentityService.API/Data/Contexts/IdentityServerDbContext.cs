using Kira.IdentityService.API.Data.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Kira.IdentityService.API.Data.Contexts;

public class IdentityServerDbContext(DbContextOptions opts) : IdentityDbContext(opts)
{
    public DbSet<RefreshToken> RefreshTokens => Set<RefreshToken>();
}
