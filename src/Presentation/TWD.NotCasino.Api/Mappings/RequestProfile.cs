using AutoMapper;
using TWD.NotCasino.Api.Core.Requests.User;
using TWD.NotCasino.Api.Core.Responses.User;
using TWD.NotCasino.Application.Commands.User;
using TWD.NotCasino.Application.Queries.User;
using TWD.NotCasino.Application.Results.User;
using TWD.NotCasino.Core.Enums.User;

namespace TWD.NotCasino.Api.Mappings;

public class RequestProfile : Profile
{
    public RequestProfile()
    {
        CreateMap<RegistrationRequest, AddUserCommand>();
        CreateMap<LoginRequest, GetUserWithPasswordQuery>();
        CreateMap<UserResult, UserInfoResponse>();

        MapEnums();
    }

    private void MapEnums()
    {
        CreateMap<UserRoles, Core.Enums.User.UserRoles>().ReverseMap();
/*            .ConvertUsing(src => (Core.Enums.User.UserRoles)src);
        CreateMap<Core.Enums.User.UserRoles, UserRoles>().ConvertUsing(src => (UserRoles)src);*/
    }
}
