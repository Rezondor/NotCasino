using TWD.NotCasino.Core.Entities.Base;
using TWD.NotCasino.Core.Enums.Games;

namespace TWD.NotCasino.Core.Entities;

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
    /// Id игры
    /// </summary>
    public long GameId { get; set; }

    /// <summary>
    /// Ставка
    /// </summary>
    public decimal Bet { get; set; }

    /// <summary>
    /// Выигрыш
    /// </summary>
    public decimal Win { get; set; }

    /// <summary>
    /// Доп информация об игре (JSON с данными игры (результаты, комбинации и т.д.))
    /// </summary>
    public string GameData { get; set; } = string.Empty;

    /// <summary>
    /// Результат игры
    /// </summary>
    public GameResults Result { get; set; }

    /// <summary>
    /// Игра
    /// </summary>
    public Game Game { get; set; } = null!;

    /// <summary>
    /// Обновление аккаунта
    /// </summary>
    public ReloadAccount ReloadAccount { get; set; } = null!;
}
