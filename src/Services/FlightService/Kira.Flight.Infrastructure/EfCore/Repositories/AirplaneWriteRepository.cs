using Kira.Flight.Domain.Entities;
using Kira.Flight.Infrastructure.EfCore.Contexts;
using Kira.Flight.Infrastructure.Interfaces.Repositories;
using Kira.Infrastructure.Shared.Repositories.EfCore;

namespace Kira.Flight.Infrastructure.EfCore.Repositories;

public class AirplaneWriteRepository : WriteEfRepository<Airplane>, IAirplaneWriteRepository
{
    public AirplaneWriteRepository(FlightWriteDbContext context) : base(context) { }
}