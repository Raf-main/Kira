using Kira.API.Shared.Controllers;
using Kira.Flight.Application.Features.Airports.Commands.CreateAirport;
using Kira.Flight.Application.Features.Airports.Queries.GetAirport;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Kira.Flight.API.Controllers
{
    [ApiController]
    [Route("api/[controller]s")]
    public class AirportController(IMediator mediator) : BasicController(mediator)
    {
        [HttpPost]
        public async Task<IActionResult> CreateAirport(CreateAirportCommand command)
        {
            var id = await Mediator.Send(command);

            return Ok(new { id });
        }

        [HttpGet("{id:guid}")]
        public async Task<IActionResult> GetAirplane(Guid id)
        {
            var command = new GetAirportCommand(id);
            var airport = await Mediator.Send(command);

            return Ok(airport);
        }
    }
}
