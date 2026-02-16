using ExpenseTracker.Infrastructure.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExpenseTracker.Application.Common.Interfaces
{
    public interface ISavingRepository
    {
        Task AddAsync(Saving savings, CancellationToken ct);
        Task <List<Saving>> GetByUserAndMonth(int userId, int year, int month);
    }
}
