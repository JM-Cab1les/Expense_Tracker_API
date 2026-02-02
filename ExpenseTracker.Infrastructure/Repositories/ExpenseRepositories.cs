using ExpenseTracker.Application.Common.Interfaces;
using ExpenseTracker.Domain.Entities;
using ExpenseTracker.Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ExpenseTracker.Infrastructure.Repositories
{
    public class ExpenseRepositories : IExpensesRepository
    {
        private readonly ExpenseTracker_DBContext _dbContext;

        public ExpenseRepositories(ExpenseTracker_DBContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task AddAsync(Expense expense, CancellationToken ct = default)
        {
            expense.CreatedDate = DateTime.Now;  
            expense.Timestamp = DateTime.Now;

            await _dbContext.Expenses.AddAsync(expense, ct);
            await _dbContext.SaveChangesAsync(ct);
        }

        public async Task<List<Expense>> GetByUserAndMonth(int userId, int year, int month)
        {
            return await _dbContext.Expenses
                .Where(e =>e.UserId == userId &&
                e.ExpenseDate.Year == year &&
                e.ExpenseDate.Month == month)
            .AsNoTracking()
            .ToListAsync();
        }

        public async Task<decimal> GetTotalForMonth(int userId, int year, int month)
        {
           return await _dbContext.Expenses
                .Where(e => e.UserId == userId &&
                e.ExpenseDate.Year == year &&
                e.ExpenseDate.Month == month)
            .SumAsync(e => e.Amount);
        }
    }
}
