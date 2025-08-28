using TWD.NotCasino.Core.Entities.Base;
using TWD.NotCasino.Core.Enums.User;

namespace TWD.NotCasino.Core.Entities;

/// <summary>
/// Пользователь
/// </summary>
public class User : BaseEntity
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
    /// Роль пользователя
    /// </summary>
    public UserRoles Role { get; set; } = UserRoles.None;

    /// <summary>
    /// Удалён ли
    /// </summary>
    public bool IsDelete { get; set; } = false;

    /// <summary>
    /// Заблокирован ли
    /// </summary>
    public bool IsBlocked { get; set; } = false;

    /// <summary>
    /// Аккаунт
    /// </summary>
    public Account Account { get; set; } = null!;

    /// <summary>
    /// Обновления аккаунтов
    /// </summary>
    public ICollection<ReloadAccount> ReloadAccounts { get; set; } = [];
}
