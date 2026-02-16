using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExpenseTracker.Application.Savings.Command.CreateSavings
{
    public record CreateSavingsCommand
    (
        int UserId,
        decimal Amount,
        string Currency,
        int Year,
        int Month
    ) : IRequest<int>;

}
