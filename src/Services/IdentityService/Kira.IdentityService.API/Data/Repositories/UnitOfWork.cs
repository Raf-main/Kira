using Kira.IdentityService.API.Data.Contexts;
using Kira.IdentityService.API.Data.Repositories.Interfaces;

using Microsoft.EntityFrameworkCore;

namespace Kira.IdentityService.API.Data.Repositories;

public class UnitOfWork(IdentityServerDbContext context, ILogger<UnitOfWork> logger) : IUnitOfWork
{
    private readonly DbContext _context = context;

#pragma warning disable CS0649
    private readonly IRefreshTokenRepository? _refreshTokenRepository;
#pragma warning restore CS0649

    public IRefreshTokenRepository RefreshTokens => _refreshTokenRepository ?? new RefreshTokenRepository(_context);

    public async Task SaveChangesAsync()
    {
        try
        {
            await _context.SaveChangesAsync();

            logger.LogInformation("Changes were successfully saved to the database");
        }
        catch (Exception ex)
        {
            logger.LogError(ex, "Saving changes to the database passed with error");

            throw;
        }
    }
}
