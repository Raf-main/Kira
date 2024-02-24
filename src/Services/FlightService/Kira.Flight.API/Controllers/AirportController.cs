using Kira.API.Shared.Controllers;
using Kira.Flight.Application.Features.Airports.Commands.CreateAirport;
using Kira.Flight.Application.Features.Airports.Queries.GetAirport;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Kira.Flight.API.Controllers
{
    [ApiController]
    [Route("[controller]s/[action]")]
    public class AirportController(IMediator mediator) : BasicController(mediator)
    {
        public async Task<IActionResult> CreateAirport(CreateAirportCommand command)
        {
            var id = await Mediator.Send(command);

            return Ok(new { id });
        }

        public async Task<IActionResult> GetAirplane(GetAirportCommand command)
        {
            var airport = await Mediator.Send(command);

            return Ok(airport);
        }
    }
}
