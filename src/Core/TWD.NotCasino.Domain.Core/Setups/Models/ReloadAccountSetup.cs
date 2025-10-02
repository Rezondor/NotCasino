using Microsoft.EntityFrameworkCore;
using TWD.NotCasino.Core.Entities;

namespace TWD.NotCasino.Domain.Core.Setups.Models;

public class ReloadAccountSetup : ISetup
{
    public int OrderNumber => int.MaxValue;

    public void Setup(ModelBuilder modelBuilder)
    {
        //Comments
        modelBuilder.Entity<ReloadAccount>().ToTable(t => t.HasComment("Обновления аккаунтов"));

        modelBuilder.Entity<ReloadAccount>().Property(x => x.UserId).HasComment("Id пользователя");
        modelBuilder.Entity<ReloadAccount>().Property(x => x.CreateDate).HasComment("Дата обновления аккаунта").HasDefaultValueSql("now() at time zone 'utc'"); ;
        modelBuilder.Entity<ReloadAccount>().Property(x => x.CreateDate).HasComment("Дата обновления аккаунта");
    }
}