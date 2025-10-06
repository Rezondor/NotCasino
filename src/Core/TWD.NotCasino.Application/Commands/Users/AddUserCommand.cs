using MediatR;
using TWD.NotCasino.Application.Results.Users;

namespace TWD.NotCasino.Application.Commands.Users;

/// <summary>
/// Добавление пользователя
/// </summary>
public class AddUserCommand : IRequest<UserResult>
{
    /// <summary>
    /// Никнейм
    /// </summary>
    public string NickName { get; set; } = null!;

    /// <summary>
    /// Логин
    /// </summary>
    public string Login { get; set; } = null!;

    /// <summary>
    /// Почта
    /// </summary>
    public string Email { get; set; } = null!;

    /// <summary>
    /// Хеш пароль
    /// </summary>
    public string Password { get; set; } = null!;
}
