using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExpenseTracker.Application.Reports.Queries.GetMonthlySummaryQuery
{
    public record GetMonthlySummaryQuery
    (
        int userId,
        int Year,
        int Month

    ): IRequest<GetMonthlySummaryResponse>;
}
