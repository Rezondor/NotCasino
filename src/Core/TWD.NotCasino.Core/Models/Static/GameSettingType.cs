using TWD.NotCasino.Core.Enums;

namespace TWD.NotCasino.Core.Models.Static;

/// <summary>
/// Настройки игры (Получать из GameSettingTypes) (РУКАМИ НЕ СОЗДАВАТЬ!)
/// </summary>
public record class GameSettingType
{
    public long Id { get; init; } = -1;
    public string DisplayNameParameter { get; init; } = string.Empty;
    public DataType DataType { get; init; } = DataType.String;
    public object? DefaultValue { get; init; } = null;

    internal GameSettingType() { }

    public static implicit operator GameSettingType?(int x) 
        => GameSettingTypes.GetValueById(x);

    public static implicit operator GameSettingType?(long x) 
        => GameSettingTypes.GetValueById(x);

    public static explicit operator long(GameSettingType x) 
        => x.Id;

    public static explicit operator int(GameSettingType x) 
        => (int)x.Id;

    public static explicit operator string?(GameSettingType x)
        => GameSettingTypes.GetNameById(x.Id);

    public static explicit operator GameSettingType?(string x)
        => GameSettingTypes.GetValueByName(x);

    public T? GetDefaultValue<T>()
    {
        return (T?)DefaultValue;
    }
}
