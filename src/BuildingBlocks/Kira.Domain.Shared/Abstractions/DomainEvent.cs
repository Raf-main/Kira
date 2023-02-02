using Kira.Domain.Shared.Interfaces;

namespace Kira.Domain.Shared.Abstractions;

public abstract class DomainEvent : IDomainEvent
{
    public Guid Id { get; }
    public abstract string EventType { get; }

    protected DomainEvent()
    {
        Id = Guid.NewGuid();
    }
}