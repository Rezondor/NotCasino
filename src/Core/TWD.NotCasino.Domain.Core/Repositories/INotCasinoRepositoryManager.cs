using System.Data;

namespace TWD.NotCasino.Domain.Core.Repositories;

/// <summary>
/// Менеджер репозиториев 
/// </summary>
public interface INotCasinoRepositoryManager
{
    /// <summary>
    /// Репозиторий для работы с пользователями
    /// </summary>
    public IUserRepository UserRepository { get; }

    /// <summary>
    /// Репозиторий для работы с серверами
    /// </summary>
    public IServerRepository ServerRepository { get; }

    /// <summary>
    /// Репозиторий для работы с аккаунтами пользователей
    /// </summary>
    public IAccountRepository AccountRepository { get; }

    /// <summary>
    /// Репозиторий для работы с играми
    /// </summary>
    public IGameRepository GameRepository { get; }

    /// <summary>
    /// Репозиторий для работы с настройками игр
    /// </summary>
    public IGameSettingRepository GameSettingRepository { get; }

    /// <summary>
    /// Открытие транзакции
    /// </summary>
    public Task StartTransactionAsync(IsolationLevel isolationLevel = IsolationLevel.ReadCommitted, CancellationToken cancellationToken = default);
    
    /// <summary>
    /// Закрытие транзакции
    /// </summary>
    public Task CommitTransactionAsync(CancellationToken cancellationToken);

    /// <summary>
    /// Откат транзакции
    /// </summary>
    public Task RollbackTransactionAsync(CancellationToken cancellationToken);

    /// <summary>
    /// Сохранение изменений
    /// </summary>
    public Task SaveChangesAsync(CancellationToken cancellationToken);
}
