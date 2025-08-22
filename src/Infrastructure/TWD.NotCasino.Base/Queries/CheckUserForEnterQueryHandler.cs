using MediatR;
using TWD.NotCasino.Application.Queries.User;
using TWD.NotCasino.Application.Results.User;

namespace TWD.NotCasino.Base.Queries;

public class CheckUserForEnterQueryHandler : IRequestHandler<CheckUserForEnterQuery, UserResult>
{
    public Task<UserResult> Handle(CheckUserForEnterQuery request, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }
}
