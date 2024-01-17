using Kira.Domain.Shared.Interfaces;

namespace Kira.Domain.Shared.Abstractions;

public abstract class DomainEvent : IDomainEvent
{
    protected DomainEvent()
    {
        Id = Guid.NewGuid();
    }

    public Guid Id { get; }
    public abstract string EventType { get; }
}