using Kira.API.Shared.Controllers;
using Kira.Flight.Application.Commands.Airplanes.CreateAirplane;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Kira.Flight.API.Controllers;

[ApiController]
[Route("[controller]s/[action]")]
public class AirplaneController(IMediator mediator) : BasicController(mediator)
{
    public async Task<IActionResult> CreateAirplane(CreateAirplaneCommand command)
    {
        var id = await Mediator.Send(command);

        return Ok(new { id });
    }
}