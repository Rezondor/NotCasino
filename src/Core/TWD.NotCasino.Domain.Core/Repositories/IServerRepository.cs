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
    public Task AddAsync(Server server, CancellationToken cancellationToken);

    /// <summary>
    /// Получение всех серверов
    /// </summary>
    public Task<IReadOnlyList<Server>> GetAllServersAsync(CancellationToken cancellationToken); 

    /// <summary>
    /// Получение сервера по Id
    /// </summary>
    public Task<Server?> GetByIdAsync(long id, CancellationToken cancellationToken); 

}
