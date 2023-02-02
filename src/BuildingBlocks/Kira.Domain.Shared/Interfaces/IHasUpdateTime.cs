namespace Kira.Domain.Shared.Interfaces;

public interface IHasUpdateTime
{
    DateTimeOffset UpdatedOn { get; }
}