using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage;
using System.Data;
using TWD.NotCasino.Domain.Base.Repositories;
using TWD.NotCasino.Domain.Core;
using TWD.NotCasino.Domain.Core.Repositories;

namespace TWD.NotCasino.Domain.Base;

public class NotCasinoRepositoryManager(NotCasinoContext context) : INotCasinoRepositoryManager
{
    private IUserRepository? _userRepository = null;
    private IServerRepository? _serverRepository = null;
    private IAccountRepository? _accountRepository = null;
    private IGameRepository? _gameRepository = null;

    public IUserRepository UserRepository { 
        get 
        { 
            return _userRepository ??= new UserRepository(context); 
        } 
    }

    public IServerRepository ServerRepository { 
        get 
        { 
            return _serverRepository ??= new ServerRepository(context); 
        } 
    }

    public IAccountRepository AccountRepository { 
        get 
        { 
            return _accountRepository ??= new AccountRepository(context); 
        } 
    }

    public IGameRepository GameRepository { 
        get 
        { 
            return _gameRepository ??= new GameRepository(context); 
        } 
    }

    private IDbContextTransaction? _transaction = null;

    /// <summary>
    /// Открытие транзакции
    /// </summary>
    public async Task StartTransactionAsync(IsolationLevel isolationLevel = IsolationLevel.ReadCommitted, CancellationToken cancellationToken = default)
    {
        if (_transaction != null)
            throw new InvalidOperationException("Transaction already started");

        _transaction = await context.Database.BeginTransactionAsync(isolationLevel, cancellationToken);
    }

    /// <summary>
    /// Коммит транзакции
    /// </summary>
    public async Task CommitTransactionAsync(CancellationToken cancellationToken)
    {
        if (_transaction == null) 
            throw new NullReferenceException("The transaction is not open");
        
        await _transaction.CommitAsync(cancellationToken);
        await _transaction.DisposeAsync();
        _transaction = null;
    }

    /// <summary>
    /// Откатывание транзакции
    /// </summary>
    public async Task RollbackTransactionAsync(CancellationToken cancellationToken)
    {
        if (_transaction == null)
            throw new InvalidOperationException("No active transaction");

        await _transaction.RollbackAsync(cancellationToken);
        await _transaction.DisposeAsync();
        _transaction = null;
    }

    /// <summary>
    /// Сохранение изменений 
    /// </summary>
    public async Task SaveChangesAsync(CancellationToken cancellationToken)
    {
        await context.SaveChangesAsync(cancellationToken);
    }
}
