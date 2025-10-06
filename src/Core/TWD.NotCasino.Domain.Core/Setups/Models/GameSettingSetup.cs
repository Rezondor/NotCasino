using Microsoft.EntityFrameworkCore;
using TWD.NotCasino.Core.Entities;

namespace TWD.NotCasino.Domain.Core.Setups.Models;

public class GameSettingSetup : ISetup
{
    public int OrderNumber => int.MaxValue;

    public void Setup(ModelBuilder modelBuilder)
    {
        //Comments
        modelBuilder.Entity<GameSetting>().ToTable(t => t.HasComment("Настройки игр"));

        modelBuilder.Entity<GameSetting>().Property(x => x.GameId).HasComment("Id игры");
        modelBuilder.Entity<GameSetting>().Property(x => x.GameSettingType).HasComment("Тип настройки");
        modelBuilder.Entity<GameSetting>().Property(x => x.Value).HasComment("Значение настройки");
    }
}