using MediatR;
using TWD.NotCasino.Application.Results.Servers;

namespace TWD.NotCasino.Application.Queries.Servers;

public class GetAllServersQuery : IRequest<IReadOnlyList<ServerResult>>
{
}
