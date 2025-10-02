using TWD.NotCasino.Api.Core.Dtos.Users;
using TWD.NotCasino.Api.Core.Enums.Users;

namespace TWD.NotCasino.Api.Core.Services;

/// <summary>
/// Получение информации по текущему пользователю
/// </summary>
public interface ICurrentUserService
{
    /// <summary>
    /// Получение полной информации о текущем авторизированном пользователе
    /// </summary>
    public CurrentUserDto? GetCurrentUser();

    /// <summary>
    /// Получение Id авторизированного пользователя
    /// </summary>
    public long? GetUserId();

    /// <summary>
    /// Получение Роли авторизированного пользователя
    /// </summary>
    public UserRoles? GetUserRole();

    /// <summary>
    /// Получение Никнейма авторизированного пользователя
    /// </summary>
    public string? GetUserNickName();

    /// <summary>
    /// Получение Почты авторизированного пользователя
    /// </summary>
    public string? GetUserEmail();
}
