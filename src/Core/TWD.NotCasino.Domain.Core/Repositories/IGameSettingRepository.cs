using TWD.NotCasino.Core.Entities;

namespace TWD.NotCasino.Domain.Core.Repositories;

/// <summary>
/// Репозиторий для таблицы Настройки игры
/// </summary>
public interface IGameSettingRepository
{
    /// <summary>
    /// Получение настроек по Id игры (Для обновления)
    /// </summary>
    /// <param name="gameId">Id игры</param>
    public Task<List<GameSetting>> GetSettingsByGameIdForUpdateAsync(long gameId, CancellationToken cancellationToken);

    /// <summary>
    /// Получение настроек по Id игры
    /// </summary>
    /// <param name="gameId">Id игры</param>
    public Task<List<GameSetting>> GetSettingsByGameIdAsync(long gameId, CancellationToken cancellationToken);

    /// <summary>
    /// Добавление настроек игры
    /// </summary>
    /// <param name="settings">Настройки игры</param>
    public Task AddSettings(ICollection<GameSetting> settings, CancellationToken cancellationToken);

    /// <summary>
    /// Удаление настроек игры
    /// </summary>
    /// <param name="settings">Настройки игры</param>
    public Task DeleteSettings(ICollection<GameSetting> settings, CancellationToken cancellationToken);
}
