using Kira.Flight.Domain.Entities;
using Kira.Infrastructure.Shared.Repositories;

namespace Kira.Flight.Infrastructure.Interfaces.Repositories;

public interface IAirportReadRepository : IAsyncReadRepository<Airport, Guid> { }