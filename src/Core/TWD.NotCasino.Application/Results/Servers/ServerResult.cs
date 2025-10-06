namespace TWD.NotCasino.Application.Results.Servers;

/// <summary>
/// Информация по серверу
/// </summary>
public class ServerResult
{
    /// <summary>
    /// Id сервера
    /// </summary>
    public long Id { get; set; }

    /// <summary>
    /// Название
    /// </summary>
    public string Name { get; set; } = null!;

    /// <summary>
    /// Количество монет
    /// </summary>
    public decimal Coins { get; set; }
}
