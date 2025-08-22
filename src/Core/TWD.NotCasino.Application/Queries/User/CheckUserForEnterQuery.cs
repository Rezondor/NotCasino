using MediatR;
using TWD.NotCasino.Application.Results.User;

namespace TWD.NotCasino.Application.Queries.User;

/// <summary>
/// Проверка пользователя по логину и паролю
/// </summary>
public class CheckUserForEnterQuery : IRequest<UserResult>
{
    /// <summary>
    /// Почта
    /// </summary>
    public string Email { get; set; } = null!;

    /// <summary>
    /// Хеш пароль
    /// </summary>
    public string Password { get; set; } = null!;
}
