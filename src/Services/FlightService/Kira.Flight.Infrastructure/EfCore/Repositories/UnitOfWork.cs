using Kira.Flight.Domain.Entities;
using Kira.Flight.Infrastructure.Interfaces;

using Light.Infrastructure.EfCore.Repositories;
using Light.Infrastructure.Extensions.Repositories;

using Microsoft.EntityFrameworkCore;

namespace Kira.Flight.Infrastructure.EfCore.Repositories;

public class UnitOfWork : IUnitOfWork
{
    protected readonly DbContext Context;

    public UnitOfWork(DbContext context)
    {
        Context = context;
        AirplaneWriteRepository = new WriteEfRepository<Airplane, Guid>(Context);
        AirportWriteRepository = new WriteEfRepository<Airport, Guid>(Context);
        FlightWriteRepository = new WriteEfRepository<Domain.Entities.Flight, Guid>(Context);
        SeatWriteRepository = new WriteEfRepository<Seat, Guid>(Context);
    }

    public IAsyncWriteRepository<Airplane, Guid> AirplaneWriteRepository { get; }
    public IAsyncWriteRepository<Airport, Guid> AirportWriteRepository { get; }
    public IAsyncWriteRepository<Domain.Entities.Flight, Guid> FlightWriteRepository { get; }
    public IAsyncWriteRepository<Seat, Guid> SeatWriteRepository { get; }

    public async Task SaveChangesAsync(CancellationToken cancellationToken)
    {
        await Context.SaveChangesAsync(cancellationToken);
    }
}
