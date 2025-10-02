using TWD.NotCasino.Core.Enums.Games;
using TWD.NotCasino.Core.Models.Games;

namespace TWD.NotCasino.Application.Results.Games;

/// <summary>
/// Информация по игре
/// </summary>
public class GameResult
{
    /// <summary>
    /// Id игры
    /// </summary>
    public long Id { get; set; }

    /// <summary>
    /// Наименование
    /// </summary>
    public string Name { get; set; }

    /// <summary>
    /// Id сервера
    /// </summary>
    public long ServerId { get; set; }

    /// <summary>
    /// Тип игры
    /// </summary>
    public GameTypes Type { get; set; }

    /// <summary>
    /// Настройки игры
    /// </summary>
    public List<GameSetting> GameSettings { get; set; } = [];
}
