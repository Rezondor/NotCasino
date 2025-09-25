using Microsoft.EntityFrameworkCore;
using TWD.NotCasino.Core.Entities;
using TWD.NotCasino.Domain.Core;
using TWD.NotCasino.Domain.Core.Repositories;

namespace TWD.NotCasino.Domain.Base.Repositories;

public class ServerRepository(NotCasinoContext context) : IServerRepository
{
    public async Task<Server> AddServerAsync(string name, decimal coins, CancellationToken cancellationToken)
    {
        var newServer = new Server
        {
            Name = name,
            Coins = coins,
        };

        await context.Servers.AddAsync(newServer);
        return newServer;
    }

    public async Task<IReadOnlyList<Server>> GetAllServers(CancellationToken cancellationToken)
    {
        return await context.Servers.ToListAsync(cancellationToken);
    }
}
