using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExpenseTracker.Application.Users.Command.LoginUser
{
    public record LoginUserCommand
    (
        string UserName,
        string Password
    ) : IRequest<LoginResult>;
}
