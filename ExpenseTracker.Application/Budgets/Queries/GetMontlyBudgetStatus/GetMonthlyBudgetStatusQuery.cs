using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExpenseTracker.Application.Budgets.Queries.GetMontlyBudgetStatus
{
    public record GetMonthlyBudgetStatusQuery
    (
        int UserId,
        int Year,
        int Month
    ) : IRequest<List<GetMonthlyStatusResponse>>;

}
