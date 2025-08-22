using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TWD.NotCasino.Api.Core.Dtos.User;

/// <summary>
/// Регистрационная модель 
/// </summary>
public class RegistrationDto
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
