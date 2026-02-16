using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExpenseTracker.Application.Savings.Queries.GetSavingsByMonth
{
    public class GetSavingsByMonthQueryResponse
    {
        public int Id { get; set; }
        public decimal Amount { get; set; }
        public string Currency { get; set; }
        public DateTime? Timestamp { get; set; }
    }
}
