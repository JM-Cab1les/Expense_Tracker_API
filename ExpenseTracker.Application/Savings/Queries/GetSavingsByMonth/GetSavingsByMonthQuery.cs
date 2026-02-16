using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExpenseTracker.Application.Savings.Queries.GetSavingsByMonth
{
    public record GetSavingsByMonthQuery
    (
        int userId,
        int year,
        int month
    ) : MediatR.IRequest<List<GetSavingsByMonthQueryResponse>>;
}
