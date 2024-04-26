using Light.Core.Extensions.Entities.Interfaces;

namespace Kira.Domain.Shared.Interfaces;

public interface IAggregate<out TKey> : IEntity<TKey>, IHasDomainEvent where TKey : struct;
