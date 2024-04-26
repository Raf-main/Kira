using MediatR;

using Microsoft.AspNetCore.Mvc;

namespace Kira.API.Shared.Controllers;

public class BasicController(IMediator mediator) : ControllerBase
{
    protected readonly IMediator Mediator = mediator;
}
