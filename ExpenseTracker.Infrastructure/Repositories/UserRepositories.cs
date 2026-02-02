using ExpenseTracker.Application.Common.Interfaces;
using ExpenseTracker.Application.Helper;
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
    public class UserRepositories : IUserRepository
    {
        private readonly ExpenseTracker_DBContext _dbContext;

        public UserRepositories(ExpenseTracker_DBContext dbContext)
        {
            _dbContext = dbContext;
        }
        public async Task AddAsync(User user, CancellationToken ct)
        {
            user.CreatedDate = DateTime.Now;
            user.Timestamp = DateTime.Now;

            await _dbContext.Users.AddAsync(user, ct);
            await _dbContext.SaveChangesAsync(ct);
        }

        public async Task<User?> GetUserName(string userName, CancellationToken ct)
        {
           return await _dbContext.Users.AsNoTracking().FirstOrDefaultAsync(u => u.UserName == userName, ct);  
        }

        public async Task<bool> VerifyPasswordAsync(User user, string providedPassword, CancellationToken ct = default)
        {
           return PasswordHasHelper.VerifyPassword(user.Password, providedPassword);
        }
    }
}
