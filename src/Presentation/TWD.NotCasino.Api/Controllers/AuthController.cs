using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
using TWD.NotCasino.Api.Core.Requests.User;
using TWD.NotCasino.Api.Core.Responses.User;
using TWD.NotCasino.Api.Core.Services;

namespace TWD.NotCasino.Api.Controllers;

[ApiController]
[Route("api/[controller]")]
public class AuthController(IAuthService authService) : ControllerBase
{
    /// <summary>
    /// Регистрация пользователя
    /// </summary>
    [HttpPost("register")]
    [ProducesResponseType(typeof(UserInfoResponse), StatusCodes.Status200OK)]
    public async Task<IActionResult> Register([FromBody] RegistrationRequest req, CancellationToken cancellationToken)
    {
        var user = await authService.RegisterAsync(req);
        return Ok(user);
    }

    /// <summary>
    /// Авторизация пользователя
    /// </summary>
    [HttpPost("login")]
    [ProducesResponseType(typeof(UserInfoResponse), StatusCodes.Status200OK)]
    public async Task<IActionResult> Login([FromBody] Core.Requests.User.LoginRequest req, CancellationToken cancellationToken)
    {
        var user = await authService.LoginAsync(req);
        return Ok(user);
    }

    /// <summary>
    /// Выход пользователя
    /// </summary>
    [Authorize]
    [HttpPost("logout")]
    public async Task<IActionResult> Logout()
    {
        await authService.LogoutAsync();
        return NoContent();
    }

    [Authorize]
    [HttpGet("me")]
    [ProducesResponseType(typeof(string), StatusCodes.Status200OK)]
    public async Task<IActionResult> Me(CancellationToken cancellationToken)
    {
        var userName = User.FindFirstValue(ClaimTypes.Name);
        if (userName is null) return Unauthorized();

        return Ok(userName);
    }
}