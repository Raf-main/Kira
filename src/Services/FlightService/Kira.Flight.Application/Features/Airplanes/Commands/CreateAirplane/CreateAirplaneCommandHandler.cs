using Kira.Flight.Domain.Entities;
using Kira.Flight.Infrastructure.Interfaces;
using MediatR;

namespace Kira.Flight.Application.Features.Airplanes.Commands.CreateAirplane;

public class CreateAirplaneCommandHandler : IRequestHandler<CreateAirplaneCommand, Guid>
{
    private readonly IUnitOfWork _unitOfWork;

    public CreateAirplaneCommandHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<Guid> Handle(CreateAirplaneCommand request, CancellationToken cancellationToken)
    {
        var airplane = Airplane.Create(request.Name, request.Model);
        await _unitOfWork.AirplaneWriteRepository.AddAsync(airplane, cancellationToken);
        await _unitOfWork.SaveChangesAsync(cancellationToken);

        return airplane.Id;
    }
}
