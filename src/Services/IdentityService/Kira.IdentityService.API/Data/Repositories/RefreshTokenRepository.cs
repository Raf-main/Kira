using Kira.IdentityService.API.Data.Models;
using Kira.Infrastructure.Shared.Repositories.EfCore;
using Microsoft.EntityFrameworkCore;

namespace Kira.IdentityService.API.Data.Repositories;

public class RefreshTokenRepository : GenericEfRepository<RefreshToken, int>, IRefreshTokenRepository
{
    public RefreshTokenRepository(DbContext context) : base(context) { }

    public async Task<RefreshToken?> GetByTokenAsync(string token)
    {
        return await Table.FirstOrDefaultAsync(t => t.Token == token);
    }
}