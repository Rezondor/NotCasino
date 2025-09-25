using TWD.NotCasino.Core.Entities.Base;

namespace TWD.NotCasino.Core.Entities;

/// <summary>
/// Настройка сервера
/// </summary>
public class Server : BaseEntity
{
    /// <summary>
    /// Название
    /// </summary>
    public string Name { get; set; } = null!;

    /// <summary>
    /// Количество монет
    /// </summary>
    public decimal Coins { get; set; }

    /// <summary>
    /// Настройки игр
    /// </summary>
    public ICollection<Game> Games { get; set; } = [];
}
