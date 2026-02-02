using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExpenseTracker.Application.Budgets.Command.CreateBudget
{
    public record CreateBudgetCommand
    (
        int UserId,
        int CategoryId,
        decimal Amount,
        string Currency,
        int Year ,
        int Month
    ) : IRequest<int>;

}
