using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using TWD.NotCasino.Api.Core.Dtos.Servers;
using TWD.NotCasino.Api.Core.Enums.User;

namespace TWD.NotCasino.Api.Controllers;

[Route("api/[controller]")]
[ApiController]
[Authorize]
public class ServerController(IMediator mediator) : ControllerBase
{
    [HttpGet(nameof(GetAllServers))]
    public async Task<IActionResult> GetAllServers()
    {
        return Ok(new List<string>());
    }

    [HttpPost(nameof(AddServer))]
    [Authorize(Roles = nameof(UserRoles.Admin))]
    public async Task<IActionResult> AddServer(ServerRequest newServer)
    {
        return Ok(new List<string>());
    }
}
