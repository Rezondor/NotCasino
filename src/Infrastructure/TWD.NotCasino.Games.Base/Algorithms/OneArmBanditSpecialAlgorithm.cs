using TWD.NotCasino.Game.Core.Models.AlgorithmSettingsModel;
using TWD.NotCasino.Game.Core.Models.Dtos;

namespace TWD.NotCasino.Games.Base.Algorithms;

/// <summary>
/// Специальный однорукий бандит
/// </summary>
/// <param name="settings">Настройки для алгоритма</param>
internal class OneArmBanditSpecialAlgorithm(OneArmBanditSpecialSettings settings)
{
    private readonly Random _random = new();
    private readonly OneArmBanditSpecialSettings _settings = settings;

    public SpinResult Play()
    {
        var randomNumber = new int[3] { _random.Next(0, 10), _random.Next(0, 10), _random.Next(0, 10) };

        var result = new SpinResult
        {
            Numbers = randomNumber,
            Multiplier = _settings.LossCoefficient
        };

        foreach (var combination in _settings.CombinationSets)
        {
            if (combination.Combinations.Any(x => IsMatch(randomNumber, x)))
            {
                result.Multiplier = combination.Multiplier;

                return result;
            }
        }

        return result;
    }

    private static bool IsMatch(int[] randomNumber, int[] number)
    {
        return number[0] == randomNumber[0] || number[1] == randomNumber[1] || number[2] == randomNumber[2];
    }
}
