using Kira.Flight.Domain.Entities;
using Kira.Flight.Infrastructure.Interfaces.Repositories;
using MediatR;

namespace Kira.Flight.Application.Features.Airplanes.CreateAirplane;

public class CreateAirplaneCommandHandler : IRequestHandler<CreateAirplaneCommand, Guid>
{
    private readonly IAirplaneWriteRepository _writeRepository;

    public CreateAirplaneCommandHandler(IAirplaneWriteRepository writeRepository)
    {
        _writeRepository = writeRepository;
    }

    public async Task<Guid> Handle(CreateAirplaneCommand request, CancellationToken cancellationToken)
    {
        var airplane = Airplane.Create(request.Name, request.Model);
        await _writeRepository.AddAsync(airplane);

        return airplane.Id;
    }
}