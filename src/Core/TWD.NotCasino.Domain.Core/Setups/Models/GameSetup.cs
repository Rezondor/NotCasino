using Microsoft.EntityFrameworkCore;
using TWD.NotCasino.Core.Entities;

namespace TWD.NotCasino.Domain.Core.Setups.Models;

public class GameSetup : ISetup
{
    public int OrderNumber => int.MaxValue;

    public void Setup(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Game>().Property(x=>x.IsAvailable).HasDefaultValue(true);

        //Comments
        modelBuilder.Entity<Game>().ToTable(t => t.HasComment("Игры"));

        modelBuilder.Entity<Game>().Property(x => x.ServerId).HasComment("Id сервера");
        modelBuilder.Entity<Game>().Property(x => x.Name).HasComment("Наименование игры");
        modelBuilder.Entity<Game>().Property(x => x.IsAvailable).HasComment("Активна ли игра");
        modelBuilder.Entity<Game>().Property(x => x.Type).HasComment("Тип игры");
    }
}
