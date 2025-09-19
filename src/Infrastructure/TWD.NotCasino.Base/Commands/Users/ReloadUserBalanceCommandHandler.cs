using MediatR;
using TWD.NotCasino.Application.Queries.Users;
using TWD.NotCasino.Core.Entities;
using TWD.NotCasino.Domain.Core.Repositories;

namespace TWD.NotCasino.Base.Commands.Users;

public class ReloadUserBalanceCommandHandler(INotCasinoRepositoryManager repositoryManager) : IRequestHandler<ReloadUserBalanceCommand>
{
    public async Task Handle(ReloadUserBalanceCommand request, CancellationToken cancellationToken)
    {
        try
        {
            await repositoryManager.StartTransactionAsync(cancellationToken: cancellationToken);

            var user = await repositoryManager.UserRepository.GetUserForUpdateAsync(request.UserId, cancellationToken);
            user.Account.Coins = repositoryManager.UserRepository.StartMoney;
            user.ReloadAccounts.Add(new ReloadAccount());

            await repositoryManager.SaveChangesAsync(cancellationToken);
            await repositoryManager.CommitTransactionAsync(cancellationToken);
        }
        catch (Exception)
        {
            await repositoryManager.RollbackTransactionAsync(cancellationToken);
            throw new Exception("Error when restarting the user account");
        }
    }
}
