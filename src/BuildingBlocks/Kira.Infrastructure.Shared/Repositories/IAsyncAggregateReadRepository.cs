using Kira.Domain.Shared.Interfaces;

namespace Kira.Infrastructure.Shared.Repositories;

public interface IAsyncAggregateReadRepository<TAggregate, in TKey> : IAsyncReadRepository<TAggregate, TKey>
    where TAggregate : IAggregate<TKey> { }