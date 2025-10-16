using System.Text.Json;
using TWD.NotCasino.Core.Enums.Games;
using TWD.NotCasino.Core.Models.Configs;
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

    public OneArmBanditBaseSettings GetOneArmBanditBaseSettings(Dictionary<GameSettingTypes, string> settings)
    {
        var result = new OneArmBanditBaseSettings
        {
            PrimaryWinningCoefficient = settings.TryGetValue(GameSettingTypes.PrimaryWinningCoefficient, out var primaryWinningCoefficient) ? double.Parse(primaryWinningCoefficient) : _defaultSettings.PrimaryWinningCoefficient,
            SecondWinningCoefficient = settings.TryGetValue(GameSettingTypes.SecondWinningCoefficient, out var secondWinningCoefficient) ? double.Parse(secondWinningCoefficient) : _defaultSettings.SecondWinningCoefficient,
            LossCoefficient = settings.TryGetValue(GameSettingTypes.LossCoefficient, out var lossCoefficient) ? double.Parse(lossCoefficient) : _defaultSettings.LossCoefficient,
        };

        return result;
    }

    public OneArmBanditSpecialSettings GetOneArmBanditSpecialSettings(Dictionary<GameSettingTypes, string> settings)
    {
        var result = new OneArmBanditSpecialSettings
        {
            LossCoefficient = settings.TryGetValue(GameSettingTypes.LossCoefficient, out var lossCoefficient) ? double.Parse(lossCoefficient) : _defaultSettings.LossCoefficient,
            CombinationSets = settings.TryGetValue(GameSettingTypes.CombinationSets, out var combinationSets) ? JsonSerializer.Deserialize<List<CombinationSet>>(combinationSets)! : _defaultSettings.CombinationSets,
        };

        return result;
    }
}
