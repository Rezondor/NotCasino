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

        modelBuilder.Entity<GameSetting>().Property(x => x.ServerId).HasComment("Id сервера");
        modelBuilder.Entity<GameSetting>().Property(x => x.GameType).HasComment("Тип игры");
        modelBuilder.Entity<GameSetting>().Property(x => x.GameSettingType).HasComment("Тип настройки");
        modelBuilder.Entity<GameSetting>().Property(x => x.Value).HasComment("Значение настройки");
    }
}