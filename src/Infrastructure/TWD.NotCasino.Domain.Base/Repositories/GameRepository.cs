using TWD.NotCasino.Core.Entities;
using TWD.NotCasino.Domain.Core;
using TWD.NotCasino.Domain.Core.Repositories;

namespace TWD.NotCasino.Domain.Base.Repositories;

public class GameRepository(NotCasinoContext context) : IGameRepository
{
    public async Task AddAsync(Game game, CancellationToken cancellationToken)
    {
        await context.Games.AddAsync(game, cancellationToken);
    }
}
