namespace TWD.NotCasino.Core.Models.Configs;

/// <summary>
/// Настройки
/// </summary>
public class DefaultSettings
{
    /// <summary>
    /// Правила
    /// </summary>
    public string Description { get; set; } = "Описание игры отсутствует.";

    /// <summary>
    /// Первичный победный коэффициент
    /// </summary>
    public double PrimaryWinningCoefficient { get; set; } = 0.0;

    /// <summary>
    /// Вторичный победный коэффициент
    /// </summary>
    public double SecondWinningCoefficient { get; set; } = 0.0;

    /// <summary>
    /// Коэффициент при проигрыше
    /// </summary>
    public double LossCoefficient { get; set; } = 0.0;

    /// <summary>
    /// Настройки комбинаций
    /// </summary>
    public List<CombinationSet> CombinationSets { get; set; } = [];
}

