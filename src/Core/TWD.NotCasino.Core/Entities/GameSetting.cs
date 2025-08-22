using TWD.NotCasino.Core.Entities.Base;
using TWD.NotCasino.Core.Enums.Games;

namespace TWD.NotCasino.Core.Entities;

/// <summary>
/// Настройка игры
/// </summary>
public class GameSetting : BaseEntity
{
    /// <summary>
    /// Id сервера
    /// </summary>
    public long ServerId { get; set; }

    /// <summary>
    /// Тип игры
    /// </summary>
    public GameTypes GameType { get; set; }

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
    public Server Server { get; set; } = null!;
}
