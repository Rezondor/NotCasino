using MediatR;
using TWD.NotCasino.Application.Queries.Servers;
using TWD.NotCasino.Application.Results.Servers;
using TWD.NotCasino.Domain.Core.Repositories;

namespace TWD.NotCasino.Base.Queries.Servers;

public class GetServerByIdQueryHandler(INotCasinoRepositoryManager repositoryManager) : IRequestHandler<GetServerByIdQuery, ServerResult>
{
    public async Task<ServerResult> Handle(GetServerByIdQuery request, CancellationToken cancellationToken)
    {
        var server = await repositoryManager.ServerRepository.GetServerById(request.Id, cancellationToken);

        return server is null
            ? throw new NullReferenceException($"Сервер с Id = {request.Id} не найден")
            : new ServerResult
            {
                Id = server.Id,
                Name = server.Name,
                Coins = server.Coins,
            };
    }
}
