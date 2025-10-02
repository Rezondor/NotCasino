using TWD.NotCasino.Api.Core.Dtos.Games;
using TWD.NotCasino.Api.Core.Enums.Games;

namespace TWD.NotCasino.Api.Core.Responses.Games;

/// <summary>
/// Информация по игре
/// </summary>
public class GameResponse
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
    public List<GameSettingDto> GameSettings { get; set; } = [];
}
