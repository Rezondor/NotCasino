using TWD.NotCasino.Core.Entities.Base;
using TWD.NotCasino.Core.Enums.Games;

namespace TWD.NotCasino.Core.Entities;

/// <summary>
/// Настройка игры
/// </summary>
public class GameSetting : BaseEntity
{
    /// <summary>
    /// Id игры
    /// </summary>
    public long GameId { get; set; }

    /// <summary>
    /// Тип настройки
    /// </summary>
    public GameSettingTypes GameSettingType { get; set; }

    /// <summary>
    /// Значение настройки
    /// </summary>
    public string Value { get; set; } = null!;

    /// <summary>
    /// Сервер
    /// </summary>
    public Game Game { get; set; } = null!;
}
