using Microsoft.EntityFrameworkCore;
using TWD.NotCasino.Core.Entities;
using TWD.NotCasino.Core.Models.User;
using TWD.NotCasino.Domain.Core;
using TWD.NotCasino.Domain.Core.Repositories;

namespace TWD.NotCasino.Domain.Base.Repositories;

public class UserRepository(NotCasinoContext context) : IUserRepository
{
    public async Task<UserInfo?> GetActiveUserInfoByEmailAsync(string email, CancellationToken cancellationToken)
    {
        return await context.Users
            .Where(x => x.Email == email && !x.IsDelete)
            .Select(user =>
                new UserInfo
                {
                    Id = user.Id,
                    Email = user.Email,
                    Login = user.Login,
                    NickName = user.NickName,
                    Password = user.Password,
                    IsBlocked = user.IsBlocked,
                    IsDelete = user.IsDelete,
                    Coins = user.Account.Coins,
                    Role = user.Role
                })
            .FirstOrDefaultAsync(cancellationToken);
    }
    public async Task<UserInfo?> GetActiveUserInfoByIdAsync(long id, CancellationToken cancellationToken)
    {
        return await context.Users
            .Where(x => x.Id == id && !x.IsDelete)
            .Select(user =>
                new UserInfo
                {
                    Id = user.Id,
                    Email = user.Email,
                    Login = user.Login,
                    NickName = user.NickName,
                    Password = user.Password,
                    IsBlocked = user.IsBlocked,
                    IsDelete = user.IsDelete,
                    Coins = user.Account.Coins,
                    Role = user.Role
                })
            .FirstOrDefaultAsync(cancellationToken);
    }

    public async Task<User?> GetUserByIdAsync(long id, CancellationToken cancellationToken)
    {
        return await context.Users
            .FirstOrDefaultAsync(x => x.Id == id, cancellationToken);
    }

    public async Task InsertUserAsync(User user, CancellationToken cancellationToken)
    {
        await context.Users.AddAsync(user, cancellationToken);
    }
}
