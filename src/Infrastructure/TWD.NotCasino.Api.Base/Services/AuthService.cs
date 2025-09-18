using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using System.Security.Claims;
using System.Text.RegularExpressions;
using TWD.NotCasino.Api.Core.Dtos;
using TWD.NotCasino.Api.Core.Requests.User;
using TWD.NotCasino.Api.Core.Responses.User;
using TWD.NotCasino.Api.Core.Services;
using TWD.NotCasino.Application.Commands.User;
using TWD.NotCasino.Application.Queries.User;
using TWD.NotCasino.Application.Results.User;
using TWD.NotCasino.Core.Entities;

namespace TWD.NotCasino.Api.Base.Services;

public class AuthService(
    IPasswordHasher<ForHashModel> hasher,
    IHttpContextAccessor httpContextAccessor,
    IMapper mapper,
    IMediator mediator) : IAuthService
{
    private readonly static string _emailPattern = @"^[^@\s]+@[^@\s]+\.[^@\s]+$";
    private readonly static string _passwordPattern = @"^(?=.*[a-z])(?=.*[A-Z])(?=.*\d)(?=.*[\W_]).{8,}$";
    private readonly HttpContext httpContext = httpContextAccessor.HttpContext;

    public async Task<UserInfoResponse> RegisterAsync(RegistrationRequest registrationRequest)
    {
        if (!ValidateRegisterRequest(registrationRequest))
        {
            throw new Exception("Некорректный email или некорректный пароль или пароли не совпадают");
        }

        PrepareRequest(registrationRequest);

        var command = mapper.Map<AddUserCommand>(registrationRequest);
        var user = await mediator.Send(command);

        var response = mapper.Map<UserInfoResponse>(user);

        await SignInAsync(response, true);

        return response;
    }

    public async Task<UserInfoResponse> LoginAsync(LoginRequest loginRequest)
    {
        var command = mapper.Map<GetUserWithPasswordQuery>(loginRequest);
        var user = await mediator.Send(command);

        if (!CheckPassword(loginRequest, user.Password))
        {
            throw new Exception("Неверный пароль");
        }

        if (user.IsBlocked)
        {
            throw new Exception("Пользователь заблокирован");
        }

        var response = mapper.Map<UserInfoResponse>(user);

        await SignInAsync(response, true);

        return response;
    }

    public async Task LogoutAsync()
    {
        await httpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
    }

    private async Task SignInAsync(UserInfoResponse user, bool remember)
    {
        var claims = new List<Claim>
        {
            new(ClaimTypes.NameIdentifier, user.Id.ToString()),
            new(ClaimTypes.Name, user.NickName),
            new(ClaimTypes.Email, user.Email),
            new(ClaimTypes.Role, user.Role.ToString()),
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

        await httpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, principal, props);
    }

    private bool ValidateRegisterRequest(RegistrationRequest registrationRequest)
    {
        var isEmailValid = Regex.IsMatch(registrationRequest.Email, _emailPattern);
        var isPasswordValid = Regex.IsMatch(registrationRequest.Password, _passwordPattern);
        var isSecondPasswordValid = Regex.IsMatch(registrationRequest.PasswordReplay, _passwordPattern);

        var isPasswordEquals = registrationRequest.Password.Equals(registrationRequest.PasswordReplay);

        return isEmailValid && isPasswordValid && isSecondPasswordValid && isPasswordEquals;
    }

    private void PrepareRequest(RegistrationRequest registrationRequest)
    {
        var hashModel = new ForHashModel
        {
            Email = registrationRequest.Email,
            Password = registrationRequest.Password,
            FirstFour = registrationRequest.Password.Take(4),
            LastFour = registrationRequest.Password.TakeLast(4),
        };

        registrationRequest.Password = hasher.HashPassword(hashModel, registrationRequest.Password);
    }

    private bool CheckPassword(LoginRequest loginRequest, string passHash)
    {
        var hashModel = new ForHashModel
        {
            Email = loginRequest.Email,
            Password = loginRequest.Password,
            FirstFour = loginRequest.Password.Take(4),
            LastFour = loginRequest.Password.TakeLast(4),
        };
        var result = hasher.VerifyHashedPassword(hashModel, passHash, loginRequest.Password);
        return result == PasswordVerificationResult.Success;
    }
}
