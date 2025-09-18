using TWD.NotCasino.Core.Entities;

namespace TWD.NotCasino.Domain.Core.Repositories;

/// <summary>
/// Репозиторий для таблицы Аккаунт
/// </summary>
public interface IAccountRepository
{
    /// <summary>
    /// Получение Аккаунта пользователя
    /// </summary>
    public Task<Account> GetUserAccountByUserId(long userId, CancellationToken cancellationToken);
}
