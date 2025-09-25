using MediatR;
using TWD.NotCasino.Application.Results.Servers;

namespace TWD.NotCasino.Application.Commands.Servers;

/// <summary>
/// Модель для добавление сервера
/// </summary>
public class AddServerCommand : IRequest<ServerResult>
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
