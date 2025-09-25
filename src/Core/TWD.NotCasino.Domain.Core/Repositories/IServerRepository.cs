using TWD.NotCasino.Core.Entities;

namespace TWD.NotCasino.Domain.Core.Repositories;

/// <summary>
/// Репозиторий для таблицы Сервера
/// </summary>
public interface IServerRepository
{
    /// <summary>
    /// Добавление сервера
    /// </summary>
    /// <param name="name">Наименование</param>
    /// <param name="coins">Количество стартовых монет</param>
    /// <returns>Сервер с Id</returns>
    public Task<Server> AddServerAsync(string name, decimal coins, CancellationToken cancellationToken);

    /// <summary>
    /// Получение всех серверов
    /// </summary>
    public Task<IReadOnlyList<Server>> GetAllServers(CancellationToken cancellationToken); 

}
