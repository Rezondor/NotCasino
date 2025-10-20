using System.Data;
using System.Reflection;
using TWD.NotCasino.Core.Enums;
using TWD.NotCasino.Core.Models.Configs;

namespace TWD.NotCasino.Core.Models.Static;

public static class GameSettingTypes
{
    private static List<GameSettingType> _gameSettingTypes;
    private static Dictionary<string, GameSettingType> _gameSettingTypeWithNameDct;
    private static Dictionary<long, GameSettingType> _gameSettingTypeWithIdDct;

    static GameSettingTypes()
    {
        var tempEnum = typeof(GameSettingTypes)
            .GetProperties(BindingFlags.Public | BindingFlags.Static | BindingFlags.GetProperty)
            .Where(x => x.PropertyType == typeof(GameSettingType))
            .ToList();

        _gameSettingTypes =
            [.. tempEnum.Select(x => (GameSettingType)x.GetValue(null)!)];

        //Это сделано чтобы ссылки были везде одинаковые на всякий случай
        _gameSettingTypeWithIdDct =
            _gameSettingTypes
            .Select(param => new KeyValuePair<long, GameSettingType>(param.Id, param))
            .ToDictionary();

        _gameSettingTypeWithNameDct =
            tempEnum
            .Select(x =>
            {
                var param = (GameSettingType)x.GetValue(null)!;
                return new KeyValuePair<string, GameSettingType>(x.Name, _gameSettingTypeWithIdDct[param.Id]);
            })
            .ToDictionary();
    }

    public static GameSettingType? GetValueById(long id)
        => _gameSettingTypeWithIdDct.GetValueOrDefault(id);

    public static GameSettingType? GetValueByName(string name)
        => _gameSettingTypeWithNameDct.GetValueOrDefault(name);

    public static string? GetNameById(long id)
        => _gameSettingTypeWithNameDct.FirstOrDefault(x => x.Value.Id == id).Key;

    public static List<GameSettingType> GetAll()
        => _gameSettingTypes;

    /// <summary>
    /// Правила
    /// </summary>
    public static GameSettingType Description { get; }
    = new GameSettingType
    {
        Id = 0,
        DisplayNameParameter = "Правила",
        DataType = DataType.String,
        DefaultValue = "Описание игры отсутствует."
    };

    /// <summary>
    /// Первичный победный коэффициент
    /// </summary>
    public static GameSettingType PrimaryWinningCoefficient { get; }
    = new GameSettingType
    {
        Id = 1,
        DisplayNameParameter = "Первичный победный коэффициент",
        DataType = DataType.Double,
        DefaultValue = 0.0
    };

    /// <summary>
    /// Вторичный победный коэффициент
    /// </summary>
    public static GameSettingType SecondWinningCoefficient { get; }
    = new GameSettingType
    {
        Id = 2,
        DisplayNameParameter = "Вторичный победный коэффициент",
        DataType = DataType.Double,
        DefaultValue = 0.0
    };

    /// <summary>
    /// Коэффициент при проигрыше
    /// </summary>
    public static GameSettingType LossCoefficient { get; }
    = new GameSettingType
    {
        Id = 3,
        DisplayNameParameter = "Коэффициент при проигрыше",
        DataType = DataType.Double,
        DefaultValue = 0.0
    };

    /// <summary>
    /// Настройки комбинаций
    /// </summary>
    public static GameSettingType CombinationSets { get; }
    = new GameSettingType
    {
        Id = 4,
        DisplayNameParameter = "Коэффициент при проигрыше",
        DataType = DataType.CombinationSets,
        DefaultValue = new List<CombinationSet>()
    };
}