using TWD.NotCasino.Game.Core.Models.AlgorithmSettingsModel;
using TWD.NotCasino.Game.Core.Models.Dtos;

namespace TWD.NotCasino.Games.Base.Algorithms;

/// <summary>
/// Стандартный однорукий бандит
/// </summary>
/// <param name="settings">Настройки для алгоритма</param>
internal class OneArmBanditBaseAlgorithm(OneArmBanditBaseSettings settings)
{
    private readonly Random _random = new();
    private readonly OneArmBanditBaseSettings _settings = settings;

    public SpinResult Play()
    {
        var randomNumber = new int[3] { _random.Next(0, 10), _random.Next(0, 10), _random.Next(0, 10) };

        var result = new SpinResult
        {
            Numbers = randomNumber,
            Multiplier = _settings.LossCoefficient
        };

        // 1% вероятность (10 комбинаций)
        if (IsThreeInRow(randomNumber))
        {
            result.Multiplier = _settings.PrimaryWinningCoefficient;
            return result;
        }
        // 27% вероятность (270 комбинаций)
        else if (IsTwoInRow(randomNumber))
        {
            result.Multiplier = _settings.SecondWinningCoefficient;
            return result;
        }

        return result;
    }

    private static bool IsTwoInRow(int[] randomNumber)
    {
        return randomNumber[0] == randomNumber[1] || randomNumber[0] == randomNumber[2] || randomNumber[1] == randomNumber[2];
    }

    private static bool IsThreeInRow(int[] randomNumber)
    {
        return randomNumber[0] == randomNumber[1] && randomNumber[1] == randomNumber[2];
    }
}
