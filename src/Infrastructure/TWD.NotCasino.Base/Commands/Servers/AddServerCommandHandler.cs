using MediatR;
using TWD.NotCasino.Application.Commands.Servers;
using TWD.NotCasino.Application.Results.Servers;
using TWD.NotCasino.Core.Entities;
using TWD.NotCasino.Domain.Core.Repositories;

namespace TWD.NotCasino.Base.Commands.Servers;

public class AddServerCommandHandler(INotCasinoRepositoryManager repositoryManager) : IRequestHandler<AddServerCommand, ServerResult>
{
    public async Task<ServerResult> Handle(AddServerCommand request, CancellationToken cancellationToken)
    {
        var server = new Server
        {
            Name = request.Name,
            Coins = request.Coins,
        };

        await repositoryManager.ServerRepository.AddAsync(server, cancellationToken);
        await repositoryManager.SaveChangesAsync(cancellationToken);

        return new ServerResult
        {
            Id = server.Id,
            Name = server.Name,
            Coins = server.Coins,
        };
    }
}
