using TWD.NotCasino.Api.Core.Enums.User;

namespace TWD.NotCasino.Api.Core.Dtos.Users;

/// <summary>
/// Текущий пользователь
/// </summary>
public class CurrentUserDto
{
    /// <summary>
    /// Id
    /// </summary>
    public long Id { get; set; }
    
    /// <summary>
    /// Никнейм
    /// </summary>
    public string NickName { get; set; } = string.Empty;

    /// <summary>
    /// Почта
    /// </summary>
    public string Email { get; set; } = string.Empty;

    /// <summary>
    /// Роль
    /// </summary>
    public UserRoles Role { get; set; }
}

