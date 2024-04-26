using Kira.API.Shared.Controllers;
using Kira.Flight.Application.Features.Airplanes.Commands.CreateAirplane;
using Kira.Flight.Application.Features.Airplanes.Queries.GetAirplane;

using MediatR;

using Microsoft.AspNetCore.Mvc;

namespace Kira.Flight.API.Controllers;

[ApiController]
[Route("api/[controller]s")]
public class AirplaneController(IMediator mediator) : BasicController(mediator)
{
    [HttpPost]
    public async Task<IActionResult> CreateAirplane(CreateAirplaneCommand command)
    {
        var id = await Mediator.Send(command);

        return Ok(new { id });
    }

    [HttpGet("{id:guid}")]
    public async Task<IActionResult> GetAirplane(Guid id)
    {
        var command = new GetAirplaneCommand(id);
        var airplane = await Mediator.Send(command);

        return Ok(airplane);
    }
}
