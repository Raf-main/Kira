using AutoMapper;
using Kira.Flight.Application.Exceptions;
using Kira.Flight.Application.Features.Airplanes.Dto;
using Kira.Flight.Domain.Entities;
using Light.Infrastructure.Extensions.Repositories;
using MediatR;

namespace Kira.Flight.Application.Features.Airplanes.Queries.GetAirplane
{
    public class GetAirplaneCommandHandler : IRequestHandler<GetAirplaneCommand, AirplaneDto>
    {
        private readonly IMapper _mapper;
        private readonly IAsyncGenericRepository<Airplane, Guid> _airplaneRepository;

        public GetAirplaneCommandHandler(IAsyncGenericRepository<Airplane, Guid> airplaneRepository, IMapper mapper)
        {
            _airplaneRepository = airplaneRepository;
            _mapper = mapper;
        }

        public async Task<AirplaneDto> Handle(GetAirplaneCommand request, CancellationToken cancellationToken)
        {
            var airplane = await _airplaneRepository.GetByKeyAsync(request.Id, cancellationToken);

            if (airplane == null)
            {
                throw new NotFoundException($"Airplane with id {request.Id} was not found");
            }

            return _mapper.Map<AirplaneDto>(airplane);
        }
    }
}
