using Microsoft.AspNetCore.Http;
using System.Security.Claims;
using TWD.NotCasino.Api.Core.Dtos.Users;
using TWD.NotCasino.Api.Core.Enums.User;
using TWD.NotCasino.Api.Core.Services;

namespace TWD.NotCasino.Api.Base.Services;

public class CurrentUserService(IHttpContextAccessor httpContextAccessor) : ICurrentUserService
{
    private ClaimsPrincipal? GetUser()
    {
        var user = httpContextAccessor.HttpContext?.User;
        if (user == null || !user.Identity?.IsAuthenticated == true)
            return null;
        return user;
    }

    public CurrentUserDto? GetCurrentUser()
    {
        var user = GetUser();
        if (user == null)
            return null;

        var idClaim = GetUserId(user);
        var nickName = GetUserNickName(user);
        var email = GetUserEmail(user);
        var roleClaim = GetUserRole(user);

        return new CurrentUserDto
        {
            Id = idClaim,
            NickName = nickName,
            Email = email,
            Role = roleClaim
        };
    }

    public long? GetUserId()
    {
        var user = GetUser();

        if (user == null)
            return null;

        return GetUserId(user);
    }

    public UserRoles? GetUserRole()
    {
        var user = GetUser();

        if (user == null)
            return null;

        return GetUserRole(user);
    }

    public string? GetUserNickName()
    {
        var user = GetUser();

        if (user == null)
            return null;

        return GetUserNickName(user);
    }

    public string? GetUserEmail()
    {
        var user = GetUser();

        if (user == null)
            return null;

        return GetUserEmail(user);
    }

    private static long GetUserId(ClaimsPrincipal user)
    {
        return long.Parse(user.FindFirst(ClaimTypes.NameIdentifier)!.Value);
    }

    private static UserRoles GetUserRole(ClaimsPrincipal user)
    {
        return Enum.Parse<UserRoles>(user.FindFirst(ClaimTypes.Role)!.Value);
    }

    private static string GetUserNickName(ClaimsPrincipal user)
    {
        return user.FindFirst(ClaimTypes.Name)!.Value;
    }

    private static string GetUserEmail(ClaimsPrincipal user)
    {
        return user.FindFirst(ClaimTypes.Email)!.Value;
    }
}
