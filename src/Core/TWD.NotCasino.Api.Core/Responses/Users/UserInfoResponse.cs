using TWD.NotCasino.Api.Core.Enums.Users;

namespace TWD.NotCasino.Api.Core.Responses.Users;

/// <summary>
/// Информация по пользователю
/// </summary>
public class UserInfoResponse
{
    /// <summary>
    /// Id
    /// </summary>
    public long Id { get; set; }

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
    /// Заблокирован ли
    /// </summary>
    public bool IsBlocked { get; set; } = false;

    /// <summary>
    /// Текущее количество монет
    /// </summary>
    public decimal Coins { get; set; } = 0;

    /// <summary>
    /// Роль пользователя
    /// </summary>
    public UserRoles Role { get; set; } = UserRoles.None;
}
