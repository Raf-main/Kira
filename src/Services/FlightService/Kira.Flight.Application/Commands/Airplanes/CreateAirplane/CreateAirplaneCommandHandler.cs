using Kira.Flight.Domain.Entities;
using Light.Infrastructure.Extensions.Repositories;
using MediatR;

namespace Kira.Flight.Application.Commands.Airplanes.CreateAirplane;

public class CreateAirplaneCommandHandler(IAsyncWriteRepository<Airplane, Guid> writeRepository)
    : IRequestHandler<CreateAirplaneCommand, Guid>
{
    public async Task<Guid> Handle(CreateAirplaneCommand request, CancellationToken cancellationToken)
    {
        var airplane = Airplane.Create(request.Name, request.Model);
        await writeRepository.AddAsync(airplane, cancellationToken);

        return airplane.Id;
    }
}