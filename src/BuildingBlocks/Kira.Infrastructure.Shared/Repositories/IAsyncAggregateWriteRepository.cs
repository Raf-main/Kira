using Kira.Domain.Shared.Interfaces;

namespace Kira.Infrastructure.Shared.Repositories;

public interface IAsyncAggregateWriteRepository<in TAggregate, TKey> : IAsyncWriteRepository<TAggregate>
    where TAggregate : IAggregate<TKey> { }