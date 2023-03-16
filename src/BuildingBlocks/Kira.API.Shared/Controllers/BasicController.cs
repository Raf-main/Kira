using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Kira.API.Shared.Controllers;

public class BasicController : ControllerBase
{
    protected readonly IMediator Mediator;

    public BasicController(IMediator mediator)
    {
        Mediator = mediator;
    }
}