using MediatR;
using TWD.NotCasino.Application.Commands.User;
using TWD.NotCasino.Application.Results.User;

namespace TWD.NotCasino.Base.Commands;

public class AddUserCommandHandler : IRequestHandler<AddUserCommand, UserResult>
{
    public Task<UserResult> Handle(AddUserCommand request, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }
}
