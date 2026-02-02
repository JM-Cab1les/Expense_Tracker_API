using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExpenseTracker.Application.Budgets.Queries.GetMontlyBudgetStatus
{
    public class GetMonthlyStatusResponse
    {
        public int Id { get; set; }
        public int CategoryId { get; set; }
        public decimal Amount { get; set; }
        public string Currency { get; set; }
        public int Month { get; set; }
        public int Year { get; set; }
    }
}
