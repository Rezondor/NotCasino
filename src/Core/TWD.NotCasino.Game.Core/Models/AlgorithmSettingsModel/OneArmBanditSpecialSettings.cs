using TWD.NotCasino.Core.Models.Configs;

namespace TWD.NotCasino.Game.Core.Models.AlgorithmSettingsModel;

/// <summary>
/// Настройки для особенного однорукого бандита
/// </summary>
public class OneArmBanditSpecialSettings
{
    /// <summary>
    /// Набор комбинаций с коэффициентами 
    /// </summary>
    public List<CombinationSet> CombinationSets { get; set; }

    /// <summary>
    /// Проигрышный коэффициента
    /// </summary>
    public double LossCoefficient { get; set; }
}
