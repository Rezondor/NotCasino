using TWD.NotCasino.Api.Core.Requests.User;
using TWD.NotCasino.Api.Core.Responses.User;

namespace TWD.NotCasino.Api.Core.Services;

public interface IAuthService
{
    public Task<UserInfoResponse> RegisterAsync(RegistrationRequest registrationRequest, CancellationToken cancellationToken);
    public Task<UserInfoResponse> LoginAsync(LoginRequest loginRequest, CancellationToken cancellationToken);
    public Task LogoutAsync();
}
