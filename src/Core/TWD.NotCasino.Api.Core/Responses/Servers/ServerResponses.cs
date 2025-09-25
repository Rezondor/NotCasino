namespace TWD.NotCasino.Api.Core.Requests.Servers;

/// <summary>
/// Информация по серверу
/// </summary>
public class ServerResponses
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