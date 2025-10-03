using MediatR;
using TWD.NotCasino.Application.Commands.GameSettings;
using TWD.NotCasino.Core.Entities;
using TWD.NotCasino.Domain.Core.Repositories;

namespace TWD.NotCasino.Base.Commands.GameSettings;

/// <summary>
/// Добавление, обновление или удаление настроек по Id игры
/// </summary>
public class CUDGameSettingCommandHandler(INotCasinoRepositoryManager repositoryManager) : IRequestHandler<CUDGameSettingCommand>
{
    public async Task Handle(CUDGameSettingCommand request, CancellationToken cancellationToken)
    {
        try
        {
            await repositoryManager.StartTransactionAsync(cancellationToken: cancellationToken);
            var settings = await repositoryManager.GameSettingRepository.GetSettingsByGameIdForUpdateAsync(request.GameId, cancellationToken);

            //_ = settings.Keys.ExceptBy(request.Settings.Select(x => x.Type), x => x).Select(settings.Remove).ToList();
            var settingsDelete = settings.ExceptBy(request.Settings.Select(x => x.Type), x => x.GameSettingType).ToList();

            var settingTypes = settings.Select(x=>x.GameSettingType).ToHashSet();
            var settingsDct = settings.ToDictionary(x => x.GameSettingType);

            var settingsAdd = new List<GameSetting>();

            foreach (var settingForUpdate in request.Settings)
            {
                var type = settingForUpdate.Type;

                if (settingTypes.Contains(type))
                {
                    //Обновляем настройки через отслеживание
                    settingsDct[type].Value = settingForUpdate.Value;
                    continue;
                }

                var newSetting = new GameSetting
                {
                    GameId = request.GameId,
                    Value = settingForUpdate.Value,
                    GameSettingType = type,
                };

                settingsAdd.Add(newSetting);
            }

            await repositoryManager.GameSettingRepository.DeleteSettings(settingsDelete, cancellationToken);
            await repositoryManager.GameSettingRepository.AddSettings(settingsAdd, cancellationToken);

            await repositoryManager.SaveChangesAsync(cancellationToken);
            await repositoryManager.CommitTransactionAsync(cancellationToken);
        }
        catch (Exception ex)
        {
            //TODO: Запись в Log
            await repositoryManager.RollbackTransactionAsync(cancellationToken);
            throw new Exception("Во время обновления настроек произошла ошибка");
        }
    }
}
