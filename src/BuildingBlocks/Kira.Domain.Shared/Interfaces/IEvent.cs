using MediatR;

namespace Kira.Domain.Shared.Interfaces;

public interface IEvent : INotification
{
    public string EventType { get; }
}
