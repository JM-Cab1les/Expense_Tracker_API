using ExpenseTracker.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExpenseTracker.Application.Common.Interfaces
{
    public interface IBudgetRepository
    {
        Task AddAsync(Budget budget, CancellationToken ct);
        Task<List<Budget>> GetByUserAndMonth(int userId, int year, int month);
        Task<decimal> GetTotalForMonth(int userId, int year, int month);
    }
}
