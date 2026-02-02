using ExpenseTracker.Application.Common.Interfaces;
using ExpenseTracker.Domain.Entities;
using ExpenseTracker.Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExpenseTracker.Infrastructure.Repositories
{
    public class BudgetRepositories : IBudgetRepository
    {
        private readonly ExpenseTracker_DBContext _dbContext;

        public BudgetRepositories(ExpenseTracker_DBContext dbContext)
        {
            _dbContext = dbContext;
        }
        public async Task AddAsync(Budget budget, CancellationToken ct = default)
        {
            try
            {
                budget.CreatedDate = DateTime.Now;
                budget.Timestamp = DateTime.Now;

                _dbContext.Budgets.AddAsync(budget, ct);
                await _dbContext.SaveChangesAsync(ct);

            }
            catch (Exception ex)
            {
                throw;

            }
        }

        public async Task<List<Budget>> GetByUserAndMonth(int userId, int year, int month)
        {
            return await _dbContext.Budgets.AsNoTracking()
              .Where(e => e.UserId == userId &&
              e.Year == year &&
              e.Month == month)
          .AsNoTracking()
          .ToListAsync();
        }

        public Task<decimal> GetTotalForMonth(int userId, int year, int month)
        {
           return _dbContext.Budgets
                .Where(e => e.UserId == userId &&
                e.Year == year &&
                e.Month == month)
            .SumAsync(e => e.Amount);
        }
    }
}
