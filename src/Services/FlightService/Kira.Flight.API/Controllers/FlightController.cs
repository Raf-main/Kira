using Kira.API.Shared.Controllers;
using Kira.Flight.Application.Features.Flights.Commands.CreateFlight;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Kira.Flight.API.Controllers
{
    [ApiController]
    [Route("api/[controller]s")]
    public class FlightController(IMediator mediator) : BasicController(mediator)
    {
        [HttpPost]
        public async Task<IActionResult> CreateFlight(CreateFlightCommand command)
        {
            var id = await Mediator.Send(command);

            return Ok(new { id });
        }
    }
}
