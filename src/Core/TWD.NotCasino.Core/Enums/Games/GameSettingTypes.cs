namespace TWD.NotCasino.Core.Enums.Games;

/// <summary>
/// Настройки
/// </summary>
public enum GameSettingTypes : byte
{
    /// <summary>
    /// Правила
    /// </summary>
    Description = 0,

    /// <summary>
    /// Первичный победный коэффициент
    /// </summary>
    PrimaryWinningCoefficient = 1,

    /// <summary>
    /// Вторичный победный коэффициент
    /// </summary>
    SecondWinningCoefficient = 2,

    /// <summary>
    /// Настройки комбинаций
    /// </summary>
    CombinationSets = 3,

    /// <summary>
    /// Коэффициент при проигрыше
    /// </summary>
    LossCoefficient = 4,
}
