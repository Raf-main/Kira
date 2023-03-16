using Kira.API.Shared.Controllers;
using Kira.Flight.Application.Features.Airports.CreateAirport;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Kira.Flight.API.Controllers;

[ApiController]
[Route("[controller]s/[action]")]
public class AirportController : BasicController
{
    public AirportController(IMediator mediator) : base(mediator) { }

    public async Task<IActionResult> CreateAirport(CreateAirportCommand command)
    {
        var id = await Mediator.Send(command);

        return Ok(new { id });
    }
}