using Microsoft.EntityFrameworkCore;

namespace TWD.NotCasino.Domain.Core.Setups;

public interface ISetup
{
    public int OrderNumber { get; }
    public void Setup(ModelBuilder modelBuilder);
}
