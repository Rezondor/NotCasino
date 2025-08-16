using Microsoft.EntityFrameworkCore;
using TWD.NotCasino.Core.Models;

namespace TWD.NotCasino.Domain.Core.Setups.Models;

public class GameLogSetup : ISetup
{
    public int OrderNumber => int.MaxValue;

    public void Setup(ModelBuilder modelBuilder)
    {
        //Comments
        modelBuilder.Entity<GameLog>().ToTable(t => t.HasComment("Логи игр"));

        modelBuilder.Entity<GameLog>().Property(x => x.Bet).HasComment("Ставка");
        modelBuilder.Entity<GameLog>().Property(x => x.GameData).HasComment("Доп информация об игре");
        modelBuilder.Entity<GameLog>().Property(x => x.GameType).HasComment("Тип игры");
        modelBuilder.Entity<GameLog>().Property(x => x.ReloadAccountId).HasComment("Id обновления аккаунта");
        modelBuilder.Entity<GameLog>().Property(x => x.Result).HasComment("Результат игры");
        modelBuilder.Entity<GameLog>().Property(x => x.ServerId).HasComment("Id сервера");
        modelBuilder.Entity<GameLog>().Property(x => x.Win).HasComment("Выигрыш");
    }
}