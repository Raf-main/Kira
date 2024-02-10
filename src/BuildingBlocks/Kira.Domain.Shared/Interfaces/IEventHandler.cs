using MediatR;

namespace Kira.Domain.Shared.Interfaces;

public interface IEventHandler : INotificationHandler<IEvent>;