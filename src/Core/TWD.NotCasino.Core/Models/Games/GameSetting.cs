using TWD.NotCasino.Core.Enums.Games;

namespace TWD.NotCasino.Core.Models.Games;

/// <summary>
/// Настройка игры
/// </summary>
public class GameSetting
{
    /// <summary>
    /// Настройка
    /// </summary>
    public string Value { get; set; } = null!;

    /// <summary>
    /// Тип настройки
    /// </summary>
    public long Type { get; set; }
}
