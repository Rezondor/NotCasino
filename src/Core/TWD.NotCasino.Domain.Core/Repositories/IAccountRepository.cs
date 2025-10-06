using TWD.NotCasino.Core.Entities;

namespace TWD.NotCasino.Domain.Core.Repositories;

/// <summary>
/// Репозиторий для таблицы Аккаунты
/// </summary>
public interface IAccountRepository
{
    /// <summary>
    /// Получение Аккаунта пользователя (Для обновления)
    /// </summary>
    public Task<Account> GetUserAccountByUserIdForUpdateAsync(long userId, CancellationToken cancellationToken);
}
