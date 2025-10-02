using AutoMapper;
using TWD.NotCasino.Api.Core.Enums.Users;
using TWD.NotCasino.Api.Core.Requests.Servers;
using TWD.NotCasino.Api.Core.Requests.Users;
using TWD.NotCasino.Api.Core.Responses.Servers;
using TWD.NotCasino.Api.Core.Responses.Users;
using TWD.NotCasino.Application.Commands.Servers;
using TWD.NotCasino.Application.Commands.User;
using TWD.NotCasino.Application.Queries.User;
using TWD.NotCasino.Application.Results.Servers;
using TWD.NotCasino.Application.Results.User;
using TWD.NotCasino.Core.Enums.User;

namespace TWD.NotCasino.Api.Mappings;

public class RequestProfile : Profile
{
    public RequestProfile()
    {
        MapRequestsToCommands();
        MapResultsToResponses();
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
    }

    private void MapResultsToResponses()
    {
        CreateMap<UserResult, UserInfoResponse>();
        CreateMap<ServerResult, ServerResponses>();
    }
}
