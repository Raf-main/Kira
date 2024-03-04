using Kira.Flight.Domain.Entities;
using Light.Infrastructure.Extensions.Repositories;

namespace Kira.Flight.Infrastructure.Interfaces
{
    public interface  IUnitOfWork
    {
        IAsyncWriteRepository<Airplane, Guid> AirplaneWriteRepository { get; }
        IAsyncWriteRepository<Airport, Guid> AirportWriteRepository { get; }
        IAsyncWriteRepository<Domain.Entities.Flight, Guid> FlightWriteRepository { get; }
        IAsyncWriteRepository<Seat, Guid> SeatWriteRepository { get; }
        Task SaveChangesAsync(CancellationToken cancellationToken);
    }
}
