using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using TWD.NotCasino.Api.Core.Dtos.Servers;
using TWD.NotCasino.Api.Core.Enums.User;
using TWD.NotCasino.Api.Core.Requests.Servers;
using TWD.NotCasino.Application.Commands.Servers;
using TWD.NotCasino.Application.Queries.Servers;

namespace TWD.NotCasino.Api.Controllers;

[Route("api/[controller]")]
[ApiController]
[Authorize]
public class ServerController(
    IMapper mapper,
    IMediator mediator) : ControllerBase
{
    [HttpGet(nameof(GetAllServers))]
    public async Task<IActionResult> GetAllServers(CancellationToken cancellationToken)
    {
        var result = await mediator.Send(new GetAllServersQuery(), cancellationToken);
        return Ok(mapper.Map<IReadOnlyList<ServerResponses>>(result));
    }

    [HttpPost(nameof(AddServer))]
    [Authorize(Roles = nameof(UserRoles.Admin))]
    public async Task<IActionResult> AddServer(ServerRequest newServer, CancellationToken cancellationToken)
    {
        var command = mapper.Map<AddServerCommand>(newServer);
        var result = await mediator.Send(command, cancellationToken);

        return Ok(mapper.Map<ServerResponses>(result));
    }
}
