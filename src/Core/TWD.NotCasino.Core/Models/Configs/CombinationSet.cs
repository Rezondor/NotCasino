namespace TWD.NotCasino.Core.Models.Configs;

/// <summary>
/// Набор "Комбинации - коэффициент"
/// </summary>
public class CombinationSet
{
    /// <summary>
    /// Комбинации
    /// </summary>
    public List<int[]> Combinations { get; set; }

    /// <summary>
    /// Коэффициент при выпадении
    /// </summary>
    public double Multiplier { get; set; }
}
