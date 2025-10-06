using Microsoft.EntityFrameworkCore;
using TWD.NotCasino.Core.Entities;
using TWD.NotCasino.Domain.Core;
using TWD.NotCasino.Domain.Core.Repositories;

namespace TWD.NotCasino.Domain.Base.Repositories;

public class ServerRepository(NotCasinoContext context) : IServerRepository
{
    public async Task AddAsync(Server server, CancellationToken cancellationToken)
    {
        await context.Servers.AddAsync(server, cancellationToken);
    }

    public async Task<IReadOnlyList<Server>> GetAllServersAsync(CancellationToken cancellationToken)
    {
        return await context.Servers.AsNoTracking().ToListAsync(cancellationToken);
    }

    public async Task<Server?> GetByIdAsync(long id, CancellationToken cancellationToken)
    {
        return await context.Servers.AsNoTracking().FirstOrDefaultAsync(s => s.Id == id, cancellationToken);
    }
}
