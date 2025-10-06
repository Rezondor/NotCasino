using MediatR;
using TWD.NotCasino.Application.Results.Users;

namespace TWD.NotCasino.Application.Queries.Users;

/// <summary>
/// Получение пользовалетя по логину
/// </summary>
public class GetUserWithPasswordQuery : IRequest<UseWithPasswordResult>
{
    /// <summary>
    /// Почта
    /// </summary>
    public string Email { get; set; } = null!;
}
