using Kira.Domain.Shared.Abstractions;

namespace Kira.Flight.Domain.Entities;

public class Airplane : Aggregate<Guid>
{
    public string Name { get; protected set; } = null!;
    public string Model { get; protected set; } = null!;

    public static Airplane Create(string name, string model)
    {
        var airplane = new Airplane
        {
            Id = Guid.NewGuid(),
            Name = name,
            Model = model
        };

        return airplane;
    }
}
