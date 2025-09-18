using System.Data;

namespace TWD.NotCasino.Domain.Core.Repositories;

public interface INotCasinoRepositoryManager
{
    public IUserRepository UserRepository { get; }

    public Task StartTransactionAsync(IsolationLevel isolationLevel = IsolationLevel.ReadCommitted, CancellationToken cancellationToken = default);
    public Task CommitTransactionAsync(CancellationToken cancellationToken);
    public Task RollbackTransactionAsync(CancellationToken cancellationToken);

    public Task SaveChangesAsync(CancellationToken cancellationToken);
}
