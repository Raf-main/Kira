using Kira.Flight.Infrastructure.EfCore.Contexts;
using Kira.Flight.Infrastructure.Interfaces.Repositories;
using Kira.Infrastructure.Shared.Repositories.EfCore;

namespace Kira.Flight.Infrastructure.EfCore.Repositories;

public class FlightWriteRepository : WriteEfRepository<Domain.Entities.Flight>, IFlightWriteRepository
{
    public FlightWriteRepository(FlightWriteDbContext context) : base(context) { }
}