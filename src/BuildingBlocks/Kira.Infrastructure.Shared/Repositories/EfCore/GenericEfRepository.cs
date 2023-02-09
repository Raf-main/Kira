using Kira.Domain.Shared.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Kira.Infrastructure.Shared.Repositories.EfCore;

public class GenericEfRepository<TEntity, TKey> : IAsyncReadRepository<TEntity, TKey>, IAsyncWriteRepository<TEntity>
    where TEntity : class, IHasKey<TKey>
{
    protected readonly DbContext Context;
    protected readonly DbSet<TEntity> Table;

    protected GenericEfRepository(DbContext context)
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
            .Take(pageSize)
            .AsNoTracking()
            .AsEnumerable());
    }

    public async Task<TEntity?> GetByKeyAsync(TKey key)
    {
        return await Table.FirstOrDefaultAsync(e => e.Id.Equals(key));
    }

    public async Task AddAsync(TEntity entity)
    {
        await Table.AddAsync(entity);
    }

    public Task UpdateAsync(TEntity entity)
    {
        Table.Update(entity);

        return Task.CompletedTask;
    }

    public Task DeleteAsync(TEntity entity)
    {
        Table.Remove(entity);

        return Task.CompletedTask;
    }
}