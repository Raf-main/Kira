using Kira.Domain.Shared.Abstractions;

namespace Kira.Flight.Domain.Entities;

public class Airport : Aggregate<Guid>
{
    public string Name { get; protected set; } = null!;

    public static Airport Create(string name)
    {
        var airport = new Airport { Id = Guid.NewGuid(), Name = name };

        return airport;
    }
}
