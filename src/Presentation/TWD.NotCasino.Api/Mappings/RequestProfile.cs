using AutoMapper;
using TWD.NotCasino.Api.Core.Dtos.Games;
using TWD.NotCasino.Api.Core.Requests.Games;
using TWD.NotCasino.Api.Core.Requests.GameSettings;
using TWD.NotCasino.Api.Core.Requests.Servers;
using TWD.NotCasino.Api.Core.Requests.Users;
using TWD.NotCasino.Api.Core.Responses.Games;
using TWD.NotCasino.Api.Core.Responses.Servers;
using TWD.NotCasino.Api.Core.Responses.Users;
using TWD.NotCasino.Application.Commands.Games;
using TWD.NotCasino.Application.Commands.GameSettings;
using TWD.NotCasino.Application.Commands.Servers;
using TWD.NotCasino.Application.Commands.Users;
using TWD.NotCasino.Application.Queries.Users;
using TWD.NotCasino.Application.Results.Games;
using TWD.NotCasino.Application.Results.Servers;
using TWD.NotCasino.Application.Results.Users;
using TWD.NotCasino.Core.Enums.User;
using TWD.NotCasino.Core.Models.Games;

namespace TWD.NotCasino.Api.Mappings;

public class RequestProfile : Profile
{
    public RequestProfile()
    {
        MapRequestsToCommands();
        MapResultsToResponses();
        MapDtosToModels();
        MapEnums();
    }

    private void MapEnums()
    {
        CreateMap<UserRoles, Core.Enums.Users.UserRoles>().ReverseMap();
    }

    private void MapRequestsToCommands()
    {
        CreateMap<RegistrationRequest, AddUserCommand>();
        CreateMap<LoginRequest, GetUserWithPasswordQuery>();
        CreateMap<ServerRequest, AddServerCommand>();
        CreateMap<AddGameRequest, AddGameCommand>();
        CreateMap<CUDGameSettingRequest, CUDGameSettingCommand>();
    }

    private void MapResultsToResponses()
    {
        CreateMap<UserResult, UserInfoResponse>();
        CreateMap<ServerResult, ServerResponse>();
        CreateMap<GameResult, GameResponse>();
    }

    private void MapDtosToModels()
    {
        CreateMap<GameSettingDto, GameSetting>().ReverseMap();
    }
}
