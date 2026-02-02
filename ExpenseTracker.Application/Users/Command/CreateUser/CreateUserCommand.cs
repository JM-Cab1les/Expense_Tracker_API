using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExpenseTracker.Application.Users.Command.CreateUser
{
    public record CreateUserCommand
    (
        string UserName,
        string Password,
        string FirstName,
        string LastName
    ) : IRequest<int>;
}
