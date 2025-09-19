namespace TWD.NotCasino.Application.Results.User;

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
