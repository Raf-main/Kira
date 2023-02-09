using Kira.IdentityService.API.Data.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Kira.IdentityService.API.Data.Contexts;

public class IdentityServerDbContext : IdentityDbContext
{
    public DbSet<RefreshToken> RefreshTokens => Set<RefreshToken>();

    public IdentityServerDbContext(DbContextOptions opts) : base(opts) { }
}