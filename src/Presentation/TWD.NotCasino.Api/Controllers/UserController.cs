using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using TWD.NotCasino.Api.Core.Services;
using TWD.NotCasino.Application.Queries.Users;

namespace TWD.NotCasino.Api.Controllers;

[Route("api/[controller]")]
[ApiController]
[Authorize]
public class UserController(ICurrentUserService currentUserService, IMediator mediator) : ControllerBase
{
    [HttpPost(nameof(ReloadUserBalance))]
    public async Task<IActionResult> ReloadUserBalance()
    {
        await mediator.Send(new ReloadUserBalanceCommand
        {
            UserId = currentUserService.GetUserId() ?? throw new Exception($"UserId is incorrect."),
        });
        return Ok();
    }
}
