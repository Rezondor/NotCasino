namespace TWD.NotCasino.Game.Core.Models.AlgorithmSettingsModel;

/// <summary>
/// Настройки для базового однорукого бандита
/// </summary>
public class OneArmBanditBaseSettings
{
    /// <summary>
    /// Главный победный коэффициент
    /// </summary>
    public double PrimaryWinningCoefficient { get; set; }

    /// <summary>
    /// Вторичный победный коэффициент
    /// </summary>
    public double SecondWinningCoefficient { get; set; }

    /// <summary>
    /// Проигрышный коэффициента
    /// </summary>
    public double LossCoefficient { get; set; }
}
