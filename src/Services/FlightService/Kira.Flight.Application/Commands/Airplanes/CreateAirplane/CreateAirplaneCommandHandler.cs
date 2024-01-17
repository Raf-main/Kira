using Kira.Flight.Domain.Entities;
using Light.Infrastructure.Extensions.Repositories;
using MediatR;

namespace Kira.Flight.Application.Commands.Airplanes.CreateAirplane;

public class CreateAirplaneCommandHandler : IRequestHandler<CreateAirplaneCommand, Guid>
{
    private readonly IAsyncWriteRepository<Airplane, Guid> _writeRepository;

    public CreateAirplaneCommandHandler(IAsyncWriteRepository<Airplane, Guid> writeRepository)
    {
        _writeRepository = writeRepository;
    }

    public async Task<Guid> Handle(CreateAirplaneCommand request, CancellationToken cancellationToken)
    {
        var airplane = Airplane.Create(request.Name, request.Model);
        await _writeRepository.AddAsync(airplane, cancellationToken);

        return airplane.Id;
    }
}