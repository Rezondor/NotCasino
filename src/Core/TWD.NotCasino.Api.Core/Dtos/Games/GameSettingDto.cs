using TWD.NotCasino.Api.Core.Enums.Games;

namespace TWD.NotCasino.Api.Core.Dtos.Games;

/// <summary>
/// Настройка игры
/// </summary>
public class GameSettingDto
{
    public string Value { get; set; } = null!;
    public GameSettingTypes Type { get; set; }
}
