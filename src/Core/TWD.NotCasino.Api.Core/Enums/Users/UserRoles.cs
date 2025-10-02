namespace TWD.NotCasino.Api.Core.Enums.Users;

/// <summary>
/// Роли пользователей
/// </summary>
public enum UserRoles : byte
{
    /// <summary>
    /// Без спец роли
    /// </summary>
    None = 0,

    /// <summary>
    /// Начальная спец роль
    /// </summary>
    Base = 1,

    /// <summary>
    /// Админ
    /// </summary>
    Admin = 2,
}
