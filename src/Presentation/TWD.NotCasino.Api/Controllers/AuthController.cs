using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.Data;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Security.Claims;
using TWD.NotCasino.Api.Core.Dtos.User;
using TWD.NotCasino.Core.Entities;
using TWD.NotCasino.Domain.Core.Repositories;

namespace TWD.NotCasino.Api.Controllers;

[ApiController]
[Route("api/[controller]")]
public class AuthController : ControllerBase
{
    private readonly INotCasinoRepositoryManager _repositoryManager;
    private readonly IPasswordHasher<User> _hasher;

    public AuthController(INotCasinoRepositoryManager repositoryManager, IPasswordHasher<User> hasher)
    {
        _repositoryManager = repositoryManager;
        _hasher = hasher;
    }

    [HttpPost("register")]
    //[ProducesResponseType(typeof(RegistrationDto), StatusCodes.Status201Created)]
    public async Task<IActionResult> Register([FromBody] RegistrationDto req, CancellationToken  cancellationToken)
    {
        var email = req.Email.Trim().ToLowerInvariant();

        // Простейшая валидация
        if (!email.Contains('@') || req.Password.Length < 6)
            return BadRequest("Некорректный email или слишком короткий пароль (мин. 6).");

        var exists = await _db.Users.AnyAsync(u => u.Email == email, cancellationToken);
        if (exists) return Conflict("Пользователь с таким email уже существует.");

        var user = new AppUser
        {
            Email = email,
            DisplayName = string.IsNullOrWhiteSpace(req.DisplayName) ? null : req.DisplayName!.Trim()
        };
        user.PasswordHash = _hasher.HashPassword(user, req.Password);

        _db.Users.Add(user);
        await _db.SaveChangesAsync(cancellationToken);

        // Автоматический вход после регистрации
        await SignInAsync(user, remember: true);

        var dto = new UserDto(user.Id, user.Email, user.DisplayName, user.Role, user.CreatedAtUtc);
        return CreatedAtAction(nameof(Me), new { }, dto);
    }

    [HttpPost("login")]
    [//ProducesResponseType(typeof(UserDto), StatusCodes.Status200OK)]
    public async Task<IActionResult> Login([FromBody] LoginDto req, CancellationToken cancellationToken)
    {
        var email = req.Email.Trim().ToLowerInvariant();

        var user = await _db.Users.FirstOrDefaultAsync(u => u.Email == email, cancellationToken);
        if (user is null || !user.IsActive)
            return Unauthorized("Неверный email или пароль.");

        var res = _hasher.VerifyHashedPassword(user, user.PasswordHash, req.Password);
        if (res == PasswordVerificationResult.Failed)
            return Unauthorized("Неверный email или пароль.");

        // Опционально — rehash если алгоритм поменялся
        if (res == PasswordVerificationResult.SuccessRehashNeeded)
        {
            user.PasswordHash = _hasher.HashPassword(user, req.Password);
            await _db.SaveChangesAsync(cancellationToken);
        }

        await SignInAsync(user, req.RememberMe);

        var dto = new UserDto(user.Id, user.Email, user.DisplayName, user.Role, user.CreatedAtUtc);
        return Ok(dto);
    }

    [Authorize]
    [HttpPost("logout")]
    public async Task<IActionResult> Logout()
    {
        await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
        return NoContent();
    }

    [Authorize]
    [HttpGet("me")]
    [ProducesResponseType(typeof(UserDto), StatusCodes.Status200OK)]
    public async Task<IActionResult> Me(CancellationToken cancellationToken)
    {
        var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
        if (userId is null) return Unauthorized();

        var guid = Guid.Parse(userId);
        var user = await _db.Users.AsNoTracking().FirstOrDefaultAsync(u => u.Id == guid, cancellationToken);
        if (user is null) return Unauthorized();

        var dto = new UserDto(user.Id, user.Email, user.DisplayName, user.Role, user.CreatedAtUtc);
        return Ok(dto);
    }

    private async Task SignInAsync(User user, bool remember)
    {
        var claims = new List<Claim>
        {
            new Claim(ClaimTypes.NameIdentifier, user.Id.ToString()),
            new Claim(ClaimTypes.Name, user.DisplayName ?? user.Email),
            new Claim(ClaimTypes.Email, user.Email),
            new Claim(ClaimTypes.Role, user.Role)
        };

        var identity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);
        var principal = new ClaimsPrincipal(identity);

        var props = new AuthenticationProperties
        {
            IsPersistent = remember,
            ExpiresUtc = remember ? DateTimeOffset.UtcNow.AddDays(14) : DateTimeOffset.UtcNow.AddHours(8),
            AllowRefresh = true,
            IssuedUtc = DateTimeOffset.UtcNow
        };

        await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, principal, props);
    }
}