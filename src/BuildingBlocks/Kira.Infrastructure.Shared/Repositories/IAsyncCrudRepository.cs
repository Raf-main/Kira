namespace Kira.Infrastructure.Shared.Repositories;

public interface IAsyncCrudRepository<TEntity, in TKey> : IAsyncWriteRepository<TEntity>,
    IAsyncReadRepository<TEntity, TKey> { }