using Kira.API.Shared.Controllers;
using Kira.Flight.Application.Features.Seats.CreateSeat;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Kira.Flight.API.Controllers;

[ApiController]
[Route("[controller]s/[action]")]
public class SeatController : BasicController
{
    public SeatController(IMediator mediator) : base(mediator) { }

    public async Task<IActionResult> CreateAirport(CreateSeatCommand command)
    {
        var id = await Mediator.Send(command);

        return Ok(new { id });
    }
}