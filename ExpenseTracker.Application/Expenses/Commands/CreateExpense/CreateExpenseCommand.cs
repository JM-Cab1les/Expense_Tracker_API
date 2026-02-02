using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExpenseTracker.Application.Expenses.Commands.CreateExpense
{
   public record CreateExpenseCommand (
        int UserId,
        int CategoryId,
        decimal Amount,
        string Currency,
        bool IsRecurring,
        DateTime ExpenseDate,
        string Description,
        DateTime Date
    ) : IRequest<int>;
}
