using TWD.NotCasino.Domain.Base.Repositories;
using TWD.NotCasino.Domain.Core;
using TWD.NotCasino.Domain.Core.Repositories;

namespace TWD.NotCasino.Domain.Base;

public class NotCasinoRepositoryManager(NotCasinoContext context) : INotCasinoRepositoryManager
{
    private IUserRepository? _userRepository = null;
    public IUserRepository UserRepository { 
        get 
        { 
            return _userRepository ??= new UserRepository(context); 
        } 
    }

    public async Task SaveChangesAsync()
    {
        await context.SaveChangesAsync();
    }
}
