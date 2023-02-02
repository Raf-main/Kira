using Microsoft.EntityFrameworkCore;

namespace Kira.Infrastructure.Shared.Repositories.EfCore;

public abstract class WriteRepository<TEntity> : IAsyncWriteRepository<TEntity>
    where TEntity : class
{
    protected readonly DbContext Context;
    protected readonly DbSet<TEntity> Table;

    protected WriteRepository(DbContext context)
    {
        Context = context;
        Table = context.Set<TEntity>();
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