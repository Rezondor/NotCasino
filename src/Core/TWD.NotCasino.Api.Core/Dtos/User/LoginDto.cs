namespace TWD.NotCasino.Api.Core.Dtos.User;

public class LoginDto
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
