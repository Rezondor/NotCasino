using Microsoft.EntityFrameworkCore;
using TWD.NotCasino.Core.Entities;
using TWD.NotCasino.Core.Entities.Base;
using TWD.NotCasino.Domain.Core.Setups;

namespace TWD.NotCasino.Domain.Core;

public class NotCasinoContext : DbContext
{
    public DbSet<User> Users { get; set; }
    public DbSet<Account> Accounts { get; set; }
    public DbSet<GameLog> GameLogs { get; set; }
    public DbSet<GameSetting> GameSettings { get; set; }
    public DbSet<ReloadAccount> ReloadAccounts { get; set; }
    public DbSet<Server> Servers { get; set; }

    public NotCasinoContext(DbContextOptions<NotCasinoContext> options) : base(options)
    {
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        Setuper.SetupModels(modelBuilder);
    }

    private void UpdateTimestamps()
    {
        var entries = ChangeTracker.Entries<DateEntity>();
        var date = DateTime.UtcNow;

        foreach (var entry in entries.Where(x => x.State != EntityState.Unchanged))
        {
            switch (entry.State)
            {
                case EntityState.Added:
                    entry.Entity.CreateDate = date;
                    break;
                case EntityState.Deleted:
                    entry.State = EntityState.Modified;
                    entry.Entity.DeleteDate = date;
                    break;
            }

            entry.Entity.UpdateDate = date;
        }
    }
}
