using TWD.NotCasino.Core.Models.Base;

namespace TWD.NotCasino.Core.Models;

/// <summary>
/// Обновление аккаунта
/// </summary>
public class ReloadAccount : CreateDateEntity
{
    /// <summary>
    /// Id пользователя
    /// </summary>
    public long UserId { get; set; }

    /// <summary>
    /// Пользователь
    /// </summary>
    public User User { get; set; } = null!;

    /// <summary>
    /// Логи игр
    /// </summary>
    public ICollection<GameLog> GameLogs = [];
}
