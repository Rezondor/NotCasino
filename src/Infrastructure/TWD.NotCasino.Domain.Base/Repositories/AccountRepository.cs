using Microsoft.EntityFrameworkCore;
using TWD.NotCasino.Core.Entities;
using TWD.NotCasino.Domain.Core;
using TWD.NotCasino.Domain.Core.Repositories;

namespace TWD.NotCasino.Domain.Base.Repositories;

public class AccountRepository(NotCasinoContext context) : IAccountRepository
{
    public async Task<Account> GetUserAccountByUserId(long userId, CancellationToken cancellationToken)
        => await context.Accounts
            .TagWith("FOR UPDATE")
            .Where(x => x.UserId == userId)
            .FirstAsync(cancellationToken);
}
