using MongoDB.Driver;
using Kira.Domain.Shared.Interfaces;

namespace Kira.Infrastructure.Shared.Repositories.MongoDb;

public abstract class Repository<TAggregate, TKey> : IAsyncCrudRepository<TAggregate, TKey>
    where TAggregate : IAggregate<TKey>
{
    protected readonly IMongoDbContext Context;
    protected readonly IMongoCollection<TAggregate> DbSet;

    protected Repository(IMongoDbContext context)
    {
        Context = context;
        DbSet = Context.GetCollection<TAggregate>();
    }

    public async Task AddAsync(TAggregate entity)
    {
        await DbSet.InsertOneAsync(entity);
    }

    public async Task UpdateAsync(TAggregate entity)
    {
        await DbSet.ReplaceOneAsync(e => e.Equals(entity.Id), entity);
    }

    public async Task DeleteAsync(TAggregate entity)
    {
        await DbSet.DeleteOneAsync(e => e.Equals(entity));
    }

    public async Task<IEnumerable<TAggregate>> GetAllAsync()
    {
        return await DbSet.AsQueryable().ToListAsync();
    }

    public Task<IEnumerable<TAggregate>> GetPagedAsync(int pageNumber, int pageSize)
    {
        throw new NotSupportedException();
    }

    public async Task<TAggregate?> GetByKeyAsync(TKey key)
    {
        return (await DbSet.FindAsync(e => e.Id.Equals(key))).First();
    }
}