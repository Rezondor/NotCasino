using TWD.NotCasino.Api.Core.Requests.User;
using TWD.NotCasino.Api.Core.Responses.User;

namespace TWD.NotCasino.Api.Core.Services;

public interface IAuthService
{
    public Task<UserInfoResponse> RegisterAsync(RegistrationRequest registrationRequest);
    public Task<UserInfoResponse> LoginAsync(LoginRequest loginRequest);
    public Task LogoutAsync();
}
