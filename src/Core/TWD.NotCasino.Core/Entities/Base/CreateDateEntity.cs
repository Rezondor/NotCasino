namespace TWD.NotCasino.Core.Entities.Base;

/// <summary>
/// Базовая сущность с датой создания 
/// </summary>
public abstract class CreateDateEntity : BaseEntity
{
    /// <summary>
    /// Дата создания
    /// </summary>
    public DateTime CreateDate { get; set; }
}
