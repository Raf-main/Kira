using Kira.Domain.Shared.Exceptions;
using Kira.Domain.Shared.Interfaces;

namespace Kira.Domain.Shared.Abstractions;

public abstract class Aggregate<TKey> : IAggregate<TKey> where TKey : struct
{
    protected IDictionary<Type, Action<object>> EventHandlers { get; set; } = new Dictionary<Type, Action<object>>();

    public TKey Id { get; protected set; }
    public ICollection<IDomainEvent> DomainEvents { get; protected set; } = new HashSet<IDomainEvent>();

    public void AddDomainEvent(IDomainEvent domainEvent)
    {
        DomainEvents.Add(domainEvent);
    }

    public void ClearDomainEvents()
    {
        DomainEvents.Clear();
    }

    public void Apply(IDomainEvent domainEvent)
    {
        var eventType = domainEvent.GetType();

        if (!EventHandlers.TryGetValue(eventType, out var handler))
        {
            throw new EventApplierIsNotRegisteredException(domainEvent);
        }

        handler(domainEvent);
    }
}
