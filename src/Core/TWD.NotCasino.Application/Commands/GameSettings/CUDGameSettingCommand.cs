using MediatR;
using TWD.NotCasino.Core.Models.Games;

namespace TWD.NotCasino.Application.Commands.GameSettings;

public class CUDGameSettingCommand : IRequest
{
    /// <summary>
    /// Id игры
    /// </summary>
    public long GameId { get; set; }
    
    /// <summary>
    /// Настройки для создания, обновления или удаления (если отсутствует)
    /// </summary>
    public List<GameSetting> Settings { get; set; }
}
