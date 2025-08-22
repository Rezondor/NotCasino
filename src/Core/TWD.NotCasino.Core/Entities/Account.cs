using TWD.NotCasino.Core.Entities.Base;

namespace TWD.NotCasino.Core.Entities;

/// <summary>
/// Аккаунт пользователя
/// </summary>
public class Account : BaseEntity
{
    /// <summary>
    /// Id пользователя
    /// </summary>
    public long UserId { get; set; }

    /// <summary>
    /// Текущее количество монет
    /// </summary>
    public decimal Coins { get; set; } = 0;

    /// <summary>
    /// Общее количество проигранных монет
    /// </summary>
    public decimal LosesMoneyCount { get; set; }

    /// <summary>
    /// Пользователь 
    /// </summary>
    public User User { get; set; } = null!;
}
