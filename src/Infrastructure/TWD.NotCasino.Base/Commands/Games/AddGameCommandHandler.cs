using MediatR;
using TWD.NotCasino.Application.Commands.Games;
using TWD.NotCasino.Application.Results.Games;
using TWD.NotCasino.Core.Entities;
using TWD.NotCasino.Domain.Core.Repositories;

namespace TWD.NotCasino.Base.Commands.Games;

public class AddGameCommandHandler(INotCasinoRepositoryManager repositoryManager) : IRequestHandler<AddGameCommand, GameResult>
{
    public async Task<GameResult> Handle(AddGameCommand request, CancellationToken cancellationToken)
    {
        var game = new Game
        {
            Name = request.Name,
            ServerId = request.ServerId,
            Type = request.Type,
            GameSettings = [.. request.GameSettings
                .Select(x => new GameSetting
                {
                    GameSettingType = x.Type,
                    Value = x.Value,
                })]
        };

        await repositoryManager.GameRepository.AddAsync(game, cancellationToken);
        await repositoryManager.SaveChangesAsync(cancellationToken);

        return new GameResult
        {
            Id = game.Id,
            GameSettings = request.GameSettings,
            Name = request.Name,
            ServerId = request.ServerId,
            Type = request.Type,
        };
    }
}
