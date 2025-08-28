namespace TWD.NotCasino.Core.Entities.Base;

/// <summary>
/// Базовая сущность с датами создания и изменения
/// </summary>
public abstract class DateEntity : CreateDateEntity
{
    /// <summary>
    /// Дата обновления
    /// </summary>
    public DateTime UpdateDate { get; set; }

    /// <summary>
    /// Дата удаления
    /// </summary>
    public DateTime? DeleteDate { get; set; }
}
