using Kira.Infrastructure.Shared.Repositories;

namespace Kira.Flight.Infrastructure.Interfaces.Repositories;

public interface IFlightReadRepository : IAsyncReadRepository<Domain.Entities.Flight, Guid> { }