using ExpenseTracker.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExpenseTracker.Application.Common.Interfaces
{
    public interface IUserRepository
    {
        Task AddAsync(User user, CancellationToken ct);
        Task<User?> GetUserName(string userName, CancellationToken ct);
        Task<bool> VerifyPasswordAsync(User user, string providedPassword, CancellationToken ct = default);
    }
}
