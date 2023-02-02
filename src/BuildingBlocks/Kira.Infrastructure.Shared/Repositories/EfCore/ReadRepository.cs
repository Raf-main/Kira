using Kira.Domain.Shared.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Kira.Infrastructure.Shared.Repositories.EfCore;

public abstract class ReadRepository<TEntity, TKey> : IAsyncReadRepository<TEntity, TKey>
    where TEntity : class, IHasKey<TKey>
{
    protected readonly DbContext Context;
    protected readonly DbSet<TEntity> Table;

    protected ReadRepository(DbContext context)
    {
        Context = context;
        Table = context.Set<TEntity>();
    }

    public async Task<IEnumerable<TEntity>> GetAllAsync()
    {
        return await Table.AsNoTracking().ToListAsync();
    }

    public Task<IEnumerable<TEntity>> GetPagedAsync(int pageNumber, int pageSize)
    {
        return Task.FromResult(Table.Skip((pageNumber - 1) * pageSize)
            .Take(50)
            .AsNoTracking()
            .AsEnumerable());
    }

    public async Task<TEntity?> GetByKeyAsync(TKey key)
    {
        return await Table.FirstOrDefaultAsync(e => e.Id.Equals(key));
    }
}