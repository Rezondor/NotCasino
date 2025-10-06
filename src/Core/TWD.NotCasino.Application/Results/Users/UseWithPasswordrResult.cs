namespace TWD.NotCasino.Application.Results.Users;

/// <summary>
/// Информация о пользователе с паролем
/// </summary>
public class UseWithPasswordResult : UserResult
{
    /// <summary>
    /// Пароль
    /// </summary>
    public string Password { get; set; } = null!;
}
