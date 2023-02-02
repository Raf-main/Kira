namespace Kira.Domain.Shared.Interfaces;

public interface IAggregate<TKey> : IEntity<TKey>, IHasDomainEvent
{

}