using ExpenseTracker.Application.Common.Interfaces;
using ExpenseTracker.Infrastructure.Models;
using ExpenseTracker.Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExpenseTracker.Infrastructure.Repositories
{
    public class SavingsRepositories : ISavingRepository
    {
        private readonly ExpenseTracker_DBContext _dbContext;

        public SavingsRepositories(ExpenseTracker_DBContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task AddAsync(Saving savings, CancellationToken ct)
        {
            try
            {
                savings.CreatedDate = DateTime.Now;
                savings.Timestamp = DateTime.Now;

                _dbContext.Savings.Add(savings);
                await _dbContext.SaveChangesAsync(ct);


            }
            catch (Exception ex)
            {

                throw new Exception("An error occurred while adding savings.", ex);
            }
        }

        public async Task<List<Saving>> GetByUserAndMonth(int userId, int year, int month)
        {
            return await _dbContext.Savings.AsNoTracking()
                .Where(s => s.UserId == userId && s.Year == year && s.Month == month)
                .AsNoTracking()
                .ToListAsync();
        }
    }
}



