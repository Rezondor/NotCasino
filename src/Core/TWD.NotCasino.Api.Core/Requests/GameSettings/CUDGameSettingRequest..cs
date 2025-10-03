using TWD.NotCasino.Api.Core.Dtos.Games;

namespace TWD.NotCasino.Api.Core.Requests.GameSettings;

public class CUDGameSettingRequest
{
    /// <summary>
    /// Id игры
    /// </summary>
    public long GameId { get; set; }

    /// <summary>
    /// Настройки для создания, обновления или удаления (если отсутствует)
    /// </summary>
    public List<GameSettingDto> Settings { get; set; } = [];
}
