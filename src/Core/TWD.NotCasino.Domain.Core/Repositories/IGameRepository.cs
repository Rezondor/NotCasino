using TWD.NotCasino.Core.Entities;

namespace TWD.NotCasino.Domain.Core.Repositories;

/// <summary>
/// Репозиторий для таблицы Игры
/// </summary>
public interface IGameRepository
{
    /// <summary>
    /// Добавление игры с настройками
    /// </summary>
    /// <param name="game"></param>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    public Task AddAsync(Game game, CancellationToken cancellationToken);
}
