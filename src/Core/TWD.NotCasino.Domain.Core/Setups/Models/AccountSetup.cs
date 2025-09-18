using Microsoft.EntityFrameworkCore;
using TWD.NotCasino.Core.Entities;

namespace TWD.NotCasino.Domain.Core.Setups.Models;

public class AccountSetup : ISetup
{
    public int OrderNumber => int.MaxValue;

    public void Setup(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Account>().Property(x=>x.Coins).HasDefaultValue(0.01m);

        //Comments
        modelBuilder.Entity<Account>().ToTable(t => t.HasComment("Аккаунты пользователя"));

        modelBuilder.Entity<Account>().Property(x => x.UserId).HasComment("Id пользователя");
        modelBuilder.Entity<Account>().Property(x => x.Coins).HasComment("Текущее количество монет");
        modelBuilder.Entity<Account>().Property(x => x.LosesMoneyCount).HasComment("Общее количество проигранных монет");
    }
}
