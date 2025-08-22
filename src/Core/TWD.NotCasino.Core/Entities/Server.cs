using TWD.NotCasino.Core.Entities.Base;
using TWD.NotCasino.Core.Enums;

namespace TWD.NotCasino.Core.Entities;

/// <summary>
/// Настройка сервера
/// </summary>
public class Server : BaseEntity
{
    /// <summary>
    /// Сервер
    /// </summary>
    public ServerNames ServerName { get; set; }

    /// <summary>
    /// Количество монет
    /// </summary>
    public decimal Coins { get; set; }

    /// <summary>
    /// Логи игр
    /// </summary>
    public ICollection<GameLog> GameLogs { get; set; } = [];

    /// <summary>
    /// Настройки игр
    /// </summary>
    public ICollection<GameSetting> GameSettings { get; set; } = [];
}
