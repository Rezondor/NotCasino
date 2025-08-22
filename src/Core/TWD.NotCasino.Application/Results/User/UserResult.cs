namespace TWD.NotCasino.Application.Results.User;

public class UserResult
{
    /// <summary>
    /// Id
    /// </summary>
    public long Id { get; set; }

    /// <summary>
    /// Никнейм
    /// </summary>
    public string NickName { get; set; } = null!;

    /// <summary>
    /// Логин
    /// </summary>
    public string Login { get; set; } = null!;

    /// <summary>
    /// Почта
    /// </summary>
    public string Email { get; set; } = null!;

    /// <summary>
    /// Удалён ли
    /// </summary>
    public bool IsDelete { get; set; } = false;

    /// <summary>
    /// Заблокирован ли
    /// </summary>
    public bool IsBlocked { get; set; } = false;

    /// <summary>
    /// Текущее количество монет
    /// </summary>
    public decimal Coins { get; set; } = 0;
}
