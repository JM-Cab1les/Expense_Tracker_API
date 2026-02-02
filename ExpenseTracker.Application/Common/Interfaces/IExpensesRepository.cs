using ExpenseTracker.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExpenseTracker.Application.Common.Interfaces
{
    public interface IExpensesRepository
    {
        Task AddAsync(Expense expense, CancellationToken ct);
        Task<List<Expense>> GetByUserAndMonth(int userId, int year, int month);
        Task<decimal> GetTotalForMonth(int userId, int year, int month);

    }
}
