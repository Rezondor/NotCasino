namespace TWD.NotCasino.Api.Core.Dtos.Servers;

public class ServerRequest
{
    /// <summary>
    /// Название
    /// </summary>
    public string Name { get; set; } = null!;

    /// <summary>
    /// Количество монет
    /// </summary>
    public decimal Coins { get; set; }
}
