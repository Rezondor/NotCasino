using Microsoft.EntityFrameworkCore;
using TWD.NotCasino.Core.Entities;

namespace TWD.NotCasino.Domain.Core.Setups.Models;

public class ServerSetup : ISetup
{
    public int OrderNumber => int.MaxValue;

    public void Setup(ModelBuilder modelBuilder)
    {
        //Comments
        modelBuilder.Entity<Server>().ToTable(t => t.HasComment("Настройки серверов"));

        modelBuilder.Entity<Server>().Property(x => x.ServerName).HasComment("Сервер");
        modelBuilder.Entity<Server>().Property(x => x.Coins).HasComment("Количество монет");
    }
}