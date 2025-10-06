using TWD.NotCasino.Core.Entities;
using TWD.NotCasino.Core.Models.User;

namespace TWD.NotCasino.Domain.Core.Repositories;

/// <summary>
/// Репозиторий для таблицы Пользователи
/// </summary>
public interface IUserRepository
{
    /// <summary>
    /// Количество стартовых монет
    /// </summary>
    public decimal StartMoney { get; }

    /// <summary>
    /// Добавление пользователя вместе с аккаунтом и первым обновлением аккаунта
    /// </summary>
    public Task AddAsync(User user, CancellationToken cancellationToken);

    /// <summary>
    /// Получение активного пользователя по почте
    /// </summary>
    /// <returns>Поверхностная информация о пользователе или null если не найден</returns>
    public Task<UserInfo?> GetActiveUserInfoByEmailAsync(string email, CancellationToken cancellationToken);

    /// <summary>
    /// Получение активного пользователя по id
    /// </summary>
    /// <returns>Поверхностная информация о пользователе или null если не найден</returns>
    public Task<UserInfo?> GetActiveUserInfoByIdAsync(long id, CancellationToken cancellationToken);

    /// <summary>
    /// Получение активного пользователя по id
    /// </summary>
    /// <returns>Поверхностная информация о пользователе или null если не найден</returns>
    public Task<User?> GetUserByIdAsync(long id, CancellationToken cancellationToken);

    /// <summary>
    /// Получение пользователя по id вместе с аккаунтом и перезагрузками
    /// </summary>
    /// <returns>Поверхностная информация о пользователе или null если не найден</returns>
    public Task<User> GetUserForUpdateAsync(long id, CancellationToken cancellationToken);
}
