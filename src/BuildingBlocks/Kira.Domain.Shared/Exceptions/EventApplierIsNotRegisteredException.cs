using Kira.Domain.Shared.Interfaces;

namespace Kira.Domain.Shared.Exceptions;

public class EventApplierIsNotRegisteredException : Exception
{
    public EventApplierIsNotRegisteredException() { }

    public EventApplierIsNotRegisteredException(IDomainEvent domainEvent) : base(
        $"No event applier registered for event {domainEvent}") { }

    public EventApplierIsNotRegisteredException(string message) : base(message) { }

    public EventApplierIsNotRegisteredException(string message, Exception innerException) : base(message,
        innerException) { }
}
