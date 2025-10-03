using Microsoft.EntityFrameworkCore;
using TWD.NotCasino.Core.Entities;
using TWD.NotCasino.Domain.Core;
using TWD.NotCasino.Domain.Core.Repositories;

namespace TWD.NotCasino.Domain.Base.Repositories;

public class GameSettingRepository(NotCasinoContext context) : IGameSettingRepository
{
    public async Task AddSettings(ICollection<GameSetting> settings, CancellationToken cancellationToken)
    {
        await context.GameSettings.AddRangeAsync(settings, cancellationToken);
    }

    public Task DeleteSettings(ICollection<GameSetting> settings, CancellationToken cancellationToken)
    {
        context.GameSettings.RemoveRange(settings);
        return Task.CompletedTask;
    }

    public async Task<List<GameSetting>> GetSettingsByGameIdAsync(long gameId, CancellationToken cancellationToken)
    {
        return await context.GameSettings.AsNoTrackingWithIdentityResolution().Where(x => x.GameId == gameId).ToListAsync(cancellationToken);
    }

    public async Task<List<GameSetting>> GetSettingsByGameIdForUpdateAsync(long gameId, CancellationToken cancellationToken)
    {
        return await context.GameSettings.TagWith("FOR UPDATE").Where(x => x.GameId == gameId).ToListAsync(cancellationToken);
    }
}
