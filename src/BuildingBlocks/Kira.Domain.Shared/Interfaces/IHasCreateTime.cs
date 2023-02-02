namespace Kira.Domain.Shared.Interfaces;

public interface IHasCreateTime
{
    DateTimeOffset CreatedOn { get; }
}