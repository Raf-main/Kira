using Kira.Flight.Domain.Entities;
using Light.Infrastructure.Extensions.Repositories;
using MediatR;

namespace Kira.Flight.Application.Features.Airplanes.Commands.CreateAirplane
{
    public class CreateAirplaneCommandHandler : IRequestHandler<CreateAirplaneCommand, Guid>
    {
        private readonly IAsyncGenericRepository<Airplane, Guid> _genericRepository;

        public CreateAirplaneCommandHandler(IAsyncGenericRepository<Airplane, Guid> genericRepository)
        {
            _genericRepository = genericRepository;
        }

        public async Task<Guid> Handle(CreateAirplaneCommand request, CancellationToken cancellationToken)
        {
            var airplane = Airplane.Create(request.Name, request.Model);
            await _genericRepository.AddAsync(airplane, cancellationToken);

            return airplane.Id;
        }
    }
}
