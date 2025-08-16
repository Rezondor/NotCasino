using TWD.NotCasino.Core.Enums;
using TWD.NotCasino.Core.Models.Base;

namespace TWD.NotCasino.Core.Models;

/// <summary>
/// Настройка сервера
/// </summary>
public class Server : BaseEntity
{
    /// <summary>
    /// Сервер
    /// </summary>
    public ServerNames Server { get; set; }

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
