using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExpenseTracker.Application.Expenses.Queries.GetExpensesByMonth
{
    public record GetExpensesByMonthQuery
    (
        int userId,
        int year,
        int month
    ) : IRequest<List<GetExpenseByMonthQueryResponse>>;
}
