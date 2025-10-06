using TWD.NotCasino.Api.Core.Requests.Users;
using TWD.NotCasino.Api.Core.Responses.Users;

namespace TWD.NotCasino.Api.Core.Services;

/// <summary>
/// Сервис авторизации
/// </summary>
public interface IAuthService
{
    /// <summary>
    /// Регистрация пользователя
    /// </summary>
    public Task<UserInfoResponse> RegisterAsync(RegistrationRequest registrationRequest, CancellationToken cancellationToken);

    /// <summary>
    /// Авторизация пользователя
    /// </summary>
    public Task<UserInfoResponse> LoginAsync(LoginRequest loginRequest, CancellationToken cancellationToken);
    
    /// <summary>
    /// Выход пользователя
    /// </summary>
    public Task LogoutAsync();
}
