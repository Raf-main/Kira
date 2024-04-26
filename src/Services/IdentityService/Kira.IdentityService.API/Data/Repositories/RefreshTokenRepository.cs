using Kira.IdentityService.API.Data.Models;
using Kira.IdentityService.API.Data.Repositories.Interfaces;
using Light.Infrastructure.EfCore.Repositories;
using Microsoft.EntityFrameworkCore;

namespace Kira.IdentityService.API.Data.Repositories;

public class RefreshTokenRepository(DbContext context)
    : GenericEfRepository<RefreshToken, int>(context), IRefreshTokenRepository
{
    public async Task<RefreshToken?> GetByTokenAsync(string token)
    {
        return await Table.FirstOrDefaultAsync(t => t.Token == token);
    }
}
