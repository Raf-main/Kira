using Kira.API.Shared.Controllers;
using Kira.Flight.Application.Features.Airplanes.Commands.CreateAirplane;
using Kira.Flight.Application.Features.Airplanes.Queries.GetAirplane;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Kira.Flight.API.Controllers
{
    [ApiController]
    [Route("[controller]s/[action]")]
    public class AirplaneController(IMediator mediator) : BasicController(mediator)
    {
        public async Task<IActionResult> CreateAirplane(CreateAirplaneCommand command)
        {
            var id = await Mediator.Send(command);

            return Ok(new { id });
        }

        public async Task<IActionResult> GetAirplane(GetAirplaneCommand command)
        {
            var airplane = await Mediator.Send(command);

            return Ok(airplane);
        }
    }
}
