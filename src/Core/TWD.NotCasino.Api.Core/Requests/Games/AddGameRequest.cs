using TWD.NotCasino.Api.Core.Dtos.Games;
using TWD.NotCasino.Api.Core.Enums.Games;

namespace TWD.NotCasino.Api.Core.Requests.Games;

/// <summary>
/// Запрос для добавления игры
/// </summary>
public class AddGameRequest
{
    /// <summary>
    /// Наименование игры
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
