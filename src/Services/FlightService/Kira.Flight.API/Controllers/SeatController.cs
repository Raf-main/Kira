using Kira.API.Shared.Controllers;
using Kira.Flight.Application.Commands.Seats.CreateSeat;
using Kira.Flight.Application.Commands.Seats.ReserveSeat;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Kira.Flight.API.Controllers;

[ApiController]
[Route("[controller]s/[action]")]
public class SeatController : BasicController
{
    public SeatController(IMediator mediator) : base(mediator) { }

    public async Task<IActionResult> CreateSeat(CreateSeatCommand command)
    {
        var id = await Mediator.Send(command);

        return Ok(new { id });
    }

    public async Task<IActionResult> ReserveSeat(ReserveSeatCommand command)
    {
        await Mediator.Send(command);

        return Ok();
    }
}