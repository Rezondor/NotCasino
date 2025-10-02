using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TWD.NotCasino.Api.Core.Requests.Users;

/// <summary>
/// Регистрационная модель 
/// </summary>
public class RegistrationRequest
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

    /// <summary>
    /// Хеш пароль повторение
    /// </summary>
    public string PasswordReplay { get; set; } = null!;
}
