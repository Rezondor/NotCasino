using TWD.NotCasino.Core.Enums;
using TWD.NotCasino.Core.Enums.Games;
using TWD.NotCasino.Core.Models.Base;

namespace TWD.NotCasino.Core.Models;

/// <summary>
/// Лог игры
/// </summary>
public class GameLog : BaseEntity
{
    /// <summary>
    /// Id обновления аккаунта
    /// </summary>
    public long ReloadAccountId { get; set; }

    /// <summary>
    /// Id сервера
    /// </summary>
    public long ServerId { get; set; }

    /// <summary>
    /// Ставка
    /// </summary>
    public int Bet { get; set; }

    /// <summary>
    /// Выигрыш
    /// </summary>
    public int Win { get; set; }

    /// <summary>
    /// Тип игры
    /// </summary>
    public GameTypes GameType { get; set; }

    /// <summary>
    /// Доп информация об игре
    /// </summary>
    public string GameData { get; set; } = string.Empty; // JSON с данными игры (результаты, комбинации и т.д.)
    
    /// <summary>
    /// Результат игры
    /// </summary>
    public GameResults Result { get; set; }

    /// <summary>
    /// Обновление аккаунта
    /// </summary>
    public ReloadAccount ReloadAccount { get; set; } = null!;

    /// <summary>
    /// Сервер
    /// </summary>
    public Server Server { get; set; } = null!;
}
