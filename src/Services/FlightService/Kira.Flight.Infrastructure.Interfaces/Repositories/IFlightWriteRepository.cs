using Kira.Infrastructure.Shared.Repositories;

namespace Kira.Flight.Infrastructure.Interfaces.Repositories;

public interface IFlightWriteRepository : IAsyncWriteRepository<Domain.Entities.Flight> { }