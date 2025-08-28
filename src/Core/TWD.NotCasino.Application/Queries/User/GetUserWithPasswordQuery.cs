using MediatR;
using TWD.NotCasino.Application.Results.User;

namespace TWD.NotCasino.Application.Queries.User;

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
