using MediatR;

namespace TWD.NotCasino.Application.Queries.Users;

public class ReloadUserBalanceCommand : IRequest
{
    public long UserId { get; set; }
}
