using Kira.API.Shared.Controllers;
using Kira.Flight.Application.Features.Seats.Commands.CreateSeat;
using Kira.Flight.Application.Features.Seats.Commands.ReserveSeat;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Kira.Flight.API.Controllers;

[ApiController]
[Route("api/seats")]
public class SeatController(IMediator mediator) : BasicController(mediator)
{
    [HttpPost]
    public async Task<IActionResult> CreateSeat([FromBody] CreateSeatCommand command)
    {
        var id = await Mediator.Send(command);

        return Ok(new { id });
    }

    [HttpPost("{id:guid}/reserve")]
    public async Task<IActionResult> ReserveSeat(Guid id)
    {
        var command = new ReserveSeatCommand(id);
        await Mediator.Send(command);

        return Ok();
    }
}
