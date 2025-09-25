using MediatR;
using TWD.NotCasino.Application.Commands.Servers;
using TWD.NotCasino.Application.Results.Servers;
using TWD.NotCasino.Domain.Core.Repositories;

namespace TWD.NotCasino.Base.Commands.Servers;

public class AddServerCommandHandler(INotCasinoRepositoryManager repositoryManager) : IRequestHandler<AddServerCommand, ServerResult>
{
    public async Task<ServerResult> Handle(AddServerCommand request, CancellationToken cancellationToken)
    {
        var newServer = await repositoryManager.ServerRepository.AddServerAsync(request.Name, request.Coins, cancellationToken);
        await repositoryManager.SaveChangesAsync(cancellationToken);

        return new ServerResult
        {
            Id = newServer.Id,
            Name = newServer.Name,
            Coins = newServer.Coins,
        };
    }
}
