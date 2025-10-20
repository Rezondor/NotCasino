using TWD.NotCasino.Core.Enums.Games;
using TWD.NotCasino.Core.Models.Static;
using TWD.NotCasino.Game.Core.Models.AlgorithmSettingsModel;

namespace TWD.NotCasino.Game.Core.Interfaces.Settings;

/// <summary>
/// Создание настроек для алгоритмов игр
/// </summary>
public interface ISettingsFactory
{
    /// <summary>
    /// Создание настроек для базового алгоритма "Однорукий бандит"
    /// </summary>
    public OneArmBanditBaseSettings GetOneArmBanditBaseSettings(Dictionary<GameSettingType, string> settings);

    /// <summary>
    /// Создание настроек для алгоритма "Однорукий бандит" с уникальными комбинациями
    /// </summary>
    public OneArmBanditSpecialSettings GetOneArmBanditSpecialSettings(Dictionary<GameSettingType, string> settings);
}
