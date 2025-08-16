using Microsoft.EntityFrameworkCore;
using TWD.NotCasino.Core.Models.Base;

namespace TWD.NotCasino.Domain.Core.Setups.Models;

public class BaseEntitySetup : ISetup
{
    public int OrderNumber => 1;

    public void Setup(ModelBuilder modelBuilder)
    {
        foreach (var entityType in modelBuilder.Model.GetEntityTypes())
        {
            if (typeof(BaseEntity).IsAssignableFrom(entityType.ClrType))
                modelBuilder.Entity(entityType.ClrType).HasKey(nameof(BaseEntity.Id));

            if (typeof(CreateDateEntity).IsAssignableFrom(entityType.ClrType))
                modelBuilder.Entity(entityType.ClrType).HasIndex(nameof(CreateDateEntity.CreateDate));

            //Comments

            if (typeof(BaseEntity).IsAssignableFrom(entityType.ClrType))
                modelBuilder.Entity(entityType.ClrType).Property(nameof(BaseEntity.Id))
                    .HasComment("Id записи");

            if (typeof(CreateDateEntity).IsAssignableFrom(entityType.ClrType))
                modelBuilder.Entity(entityType.ClrType).Property(nameof(CreateDateEntity.CreateDate))
                    .HasComment("Дата создания");

            if (typeof(DateEntity).IsAssignableFrom(entityType.ClrType))
                modelBuilder.Entity(entityType.ClrType).Property(nameof(DateEntity.UpdateDate))
                    .HasComment("Дата обновления");

            if (typeof(DateEntity).IsAssignableFrom(entityType.ClrType))
                modelBuilder.Entity(entityType.ClrType).Property(nameof(DateEntity.DeleteDate))
                    .HasComment("Дата удаления");
        }
    }
}
