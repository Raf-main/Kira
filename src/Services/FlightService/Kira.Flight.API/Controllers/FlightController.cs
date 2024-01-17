using Kira.API.Shared.Controllers;
using Kira.Flight.Application.Commands.Flights.CreateFlight;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Kira.Flight.API.Controllers;

[ApiController]
[Route("[controller]s/[action]")]
public class FlightController : BasicController
{
    public FlightController(IMediator mediator) : base(mediator) { }

    public async Task<IActionResult> CreateFlight(CreateFlightCommand command)
    {
        var id = await Mediator.Send(command);

        return Ok(new { id });
    }
}