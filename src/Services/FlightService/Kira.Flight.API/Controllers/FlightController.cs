using Kira.API.Shared.Controllers;
using Kira.Flight.Application.Features.Flights.CreateFlight;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Kira.Flight.API.Controllers
{
    [ApiController]
    [Route("[controller]s/[action]")]
    public class FlightController(IMediator mediator) : BasicController(mediator)
    {
        public async Task<IActionResult> CreateFlight(CreateFlightCommand command)
        {
            var id = await Mediator.Send(command);

            return Ok(new { id });
        }
    }
}
