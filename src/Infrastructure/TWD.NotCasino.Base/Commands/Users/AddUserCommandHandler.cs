using MediatR;
using TWD.NotCasino.Application.Commands.User;
using TWD.NotCasino.Application.Results.User;
using TWD.NotCasino.Core.Entities;
using TWD.NotCasino.Domain.Core.Repositories;

namespace TWD.NotCasino.Base.Commands.Users;


/// <summary>
/// Добавление пользователя 
/// </summary>
public class AddUserCommandHandler(INotCasinoRepositoryManager repositoryManager) : IRequestHandler<AddUserCommand, UserResult>
{
    public async Task<UserResult> Handle(AddUserCommand request, CancellationToken cancellationToken)
    {
        var lowerEmail = request.Email.ToLower();

        var findUser = await repositoryManager.UserRepository.GetActiveUserInfoByEmailAsync(lowerEmail, cancellationToken);

        if (findUser != null)
        {
            throw new Exception("Email занят");
        }

        var user = new User
        {
            Email = lowerEmail,
            Login = request.Login,
            Password = request.Password,
            NickName = request.NickName,
            Account = new Account
            {
                Coins = repositoryManager.UserRepository.StartMoney,
                LosesMoneyCount = 0,
            },
            ReloadAccounts =
            [
                new ReloadAccount()
            ]
        };

        await repositoryManager.UserRepository.AddAsync(user, cancellationToken);
        await repositoryManager.SaveChangesAsync(cancellationToken);

        return new UserResult
        {
            Id = user.Id,
            Email = user.Email,
            IsBlocked = user.IsBlocked,
            Login = user.Login,
            NickName = user.NickName,
            Coins = user.Account.Coins,
            Role = user.Role
        };
    }
}
