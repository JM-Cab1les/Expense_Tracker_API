using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExpenseTracker.Application.Reports.Queries.GetMonthlySummaryQuery
{
    public class GetMonthlySummaryResponse
    {
        public decimal TotalSpent { get; set; }
        public decimal TotalBudget { get; set; }
        public decimal RemainingBudget => TotalBudget - TotalSpent;
        public bool IsOverBudget => TotalSpent > TotalBudget;
    }
}
