using TWD.NotCasino.Core.Entities.Base;
using TWD.NotCasino.Core.Enums.Games;

namespace TWD.NotCasino.Core.Entities;

/// <summary>
/// Игры
/// </summary>
public class Game : BaseEntity
{
    /// <summary>
    /// Id сервера
    /// </summary>
    public long ServerId { get; set; }

    /// <summary>
    /// Тип игры
    /// </summary>
    public GameTypes Type { get; set; }

    /// <summary>
    /// Наименование игры
    /// </summary>
    public string Name { get; set; } = null!;

    /// <summary>
    /// Активна ли игра
    /// </summary>
    public bool IsAvailable { get; set; } = true;

    /// <summary>
    /// Сервер
    /// </summary>
    public Server Server { get; set; } = null!;
}
