using TWD.NotCasino.Core.Models.User;

namespace TWD.NotCasino.Domain.Core.Repositories;

public interface IUserRepository
{
    /// <summary>
    /// Получение пользователя по почте и паролю
    /// </summary>
    /// <returns>Поверхностная информация о пользователе или null если не найден</returns>
    public Task<UserInfo?> GetUserByEmailAndPassword(string email, string password);
}
