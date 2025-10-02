namespace TWD.NotCasino.Api.Core.Requests.Users;

public class LoginRequest
{
    /// <summary>
    /// Почта
    /// </summary>
    public string Email { get; set; } = null!;

    /// <summary>
    /// Хеш пароль
    /// </summary>
    public string Password { get; set; } = null!;
}
