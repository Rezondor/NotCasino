using MediatR;
using TWD.NotCasino.Application.Results.Games;
using TWD.NotCasino.Core.Enums.Games;
using TWD.NotCasino.Core.Models.Games;

namespace TWD.NotCasino.Application.Commands.Games;

/// <summary>
/// Команда для добавления игры вместе с настройками 
/// </summary>
public class AddGameCommand : IRequest<GameResult>
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
    public List<GameSetting> GameSettings { get; set; } = [];
}
