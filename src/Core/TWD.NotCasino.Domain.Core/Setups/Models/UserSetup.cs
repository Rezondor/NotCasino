using Microsoft.EntityFrameworkCore;
using TWD.NotCasino.Core.Models;

namespace TWD.NotCasino.Domain.Core.Setups.Models;

internal class UserSetup : ISetup
{
    public int OrderNumber => int.MaxValue;

    public void Setup(ModelBuilder modelBuilder)
    {
        //Comments
        modelBuilder.Entity<User>().ToTable(t => t.HasComment("Пользователи"));

        modelBuilder.Entity<User>().Property(x => x.NickName).HasComment("Никнейм");
        modelBuilder.Entity<User>().Property(x => x.Login).HasComment("Логин");
        modelBuilder.Entity<User>().Property(x => x.Email).HasComment("Почта");
        modelBuilder.Entity<User>().Property(x => x.Password).HasComment("Хеш пароль");
        modelBuilder.Entity<User>().Property(x => x.IsDelete).HasComment("Удалён ли");
        modelBuilder.Entity<User>().Property(x => x.IsBlocked).HasComment("Заблокирован ли");
    }
}
