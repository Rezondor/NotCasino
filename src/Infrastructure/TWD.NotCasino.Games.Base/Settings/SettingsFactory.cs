using System.Text.Json;
using TWD.NotCasino.Core.Models.Configs;
using TWD.NotCasino.Core.Models.Static;
using TWD.NotCasino.Game.Core.Interfaces.Settings;
using TWD.NotCasino.Game.Core.Models.AlgorithmSettingsModel;

namespace TWD.NotCasino.Games.Base.Settings;

public class SettingsFactory : ISettingsFactory
{
    private readonly DefaultSettings _defaultSettings;

    public SettingsFactory()
    {
        _defaultSettings = new DefaultSettings();
    }

    public OneArmBanditBaseSettings GetOneArmBanditBaseSettings(Dictionary<GameSettingType, string> settings)
    {
        var result = new OneArmBanditBaseSettings
        {
            PrimaryWinningCoefficient = settings.TryGetValue(GameSettingTypes.PrimaryWinningCoefficient, out var primaryWinningCoefficient) ? double.Parse(primaryWinningCoefficient) : GameSettingTypes.PrimaryWinningCoefficient.GetDefaultValue<double>(),
            SecondWinningCoefficient = settings.TryGetValue(GameSettingTypes.SecondWinningCoefficient, out var secondWinningCoefficient) ? double.Parse(secondWinningCoefficient) : GameSettingTypes.SecondWinningCoefficient.GetDefaultValue<double>(),
            LossCoefficient = settings.TryGetValue(GameSettingTypes.LossCoefficient, out var lossCoefficient) ? double.Parse(lossCoefficient) : GameSettingTypes.LossCoefficient.GetDefaultValue<double>(),
        };

        return result;
    }

    public OneArmBanditSpecialSettings GetOneArmBanditSpecialSettings(Dictionary<GameSettingType, string> settings)
    {
        var result = new OneArmBanditSpecialSettings
        {
            LossCoefficient = settings.TryGetValue(GameSettingTypes.LossCoefficient, out var lossCoefficient) ? double.Parse(lossCoefficient) : GameSettingTypes.LossCoefficient.GetDefaultValue<double>(),
            CombinationSets = settings.TryGetValue(GameSettingTypes.CombinationSets, out var combinationSets) ? JsonSerializer.Deserialize<List<CombinationSet>>(combinationSets)! : GameSettingTypes.CombinationSets.GetDefaultValue<List<CombinationSet>>()!,
        };

        return result;
    }
}
