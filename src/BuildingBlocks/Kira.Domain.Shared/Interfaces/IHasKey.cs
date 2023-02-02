namespace Kira.Domain.Shared.Interfaces;

public interface IHasKey<T>
{
    T Id { get; }
}