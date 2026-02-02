using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExpenseTracker.Application.Expenses.Queries.GetExpensesByMonth
{
    public class GetExpenseByMonthQueryResponse
    {
        public int Id { get; set; }
        public decimal Amount { get; set; }
        public string Currency { get; set; }
        public bool? IsRecurring { get; set; }
        public DateTime ExpenseDate { get; set; }
        public string Description { get; set; }

    }
}
