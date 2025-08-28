namespace TWD.NotCasino.Api.Core.Dtos;

/// <summary>
/// Модель для хеширования пароля
/// </summary>
public class ForHashModel
{
    /// <summary>
    /// Логин
    /// </summary>
    public string Email { get; set; }

    /// <summary>
    /// Пароль
    /// </summary>
    public string Password { get; set; }

    /// <summary>
    /// первые 4 буквы 
    /// </summary>
    public IEnumerable<char> FirstFour { get; set; }

    /// <summary>
    /// Последние 4 буквы
    /// </summary>
    public IEnumerable<char> LastFour { get; set; }
}
