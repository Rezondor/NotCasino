using MediatR;
using TWD.NotCasino.Application.Queries.Servers;
using TWD.NotCasino.Application.Results.Servers;
using TWD.NotCasino.Domain.Core.Repositories;

namespace TWD.NotCasino.Base.Queries.Servers;

public class GetAllServersQueryHandler(INotCasinoRepositoryManager repositoryManager) : IRequestHandler<GetAllServersQuery, IReadOnlyList<ServerResult>>
{
    public async Task<IReadOnlyList<ServerResult>> Handle(GetAllServersQuery request, CancellationToken cancellationToken)
    {
        var servers = await repositoryManager.ServerRepository.GetAllServersAsync(cancellationToken);
        return [.. servers.Select(x=>new ServerResult
        {
            Id = x.Id,
            Name = x.Name,
            Coins = x.Coins,
        })];
    }
}
