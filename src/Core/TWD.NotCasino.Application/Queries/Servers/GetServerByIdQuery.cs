using MediatR;
using TWD.NotCasino.Application.Results.Servers;

namespace TWD.NotCasino.Application.Queries.Servers;

public class GetServerByIdQuery : IRequest<ServerResult>
{
    public long Id { get; set; }
}
