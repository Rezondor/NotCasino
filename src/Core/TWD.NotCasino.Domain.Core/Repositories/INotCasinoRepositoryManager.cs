namespace TWD.NotCasino.Domain.Core.Repositories;

public interface INotCasinoRepositoryManager
{
    public IUserRepository UserRepository { get; }
    public Task SaveChangesAsync(CancellationToken cancellationToken);
}
