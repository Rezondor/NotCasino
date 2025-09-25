using MediatR;
using TWD.NotCasino.Application.Queries.User;
using TWD.NotCasino.Application.Results.User;
using TWD.NotCasino.Domain.Core.Repositories;

namespace TWD.NotCasino.Base.Queries.Users;

/// <summary>
/// Получение пользователя по логину
/// </summary>
public class GetUserWithPasswordQueryHandler(INotCasinoRepositoryManager repositoryManager) : IRequestHandler<GetUserWithPasswordQuery, UseWithPasswordResult>
{
    public async Task<UseWithPasswordResult> Handle(GetUserWithPasswordQuery request, CancellationToken cancellationToken)
    {
        var lowerEmail = request.Email.ToLower();
        var findUser = await repositoryManager.UserRepository.GetActiveUserInfoByEmailAsync(lowerEmail, cancellationToken)
            ?? throw new Exception("Пользователь не найден");

        return new UseWithPasswordResult
        {
            Id = findUser.Id,
            Coins = findUser.Coins,
            Email = findUser.Email,
            IsBlocked = findUser.IsBlocked,
            Login = findUser.Login,
            NickName = findUser.NickName,
            Password = findUser.Password,
            Role = findUser.Role
        };
    }
}
