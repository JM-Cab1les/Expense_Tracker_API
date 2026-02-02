using ExpenseTracker.Application.Common.Interfaces;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExpenseTracker.Application.Reports.Queries.GetMonthlySummaryQuery
{
    public class GetMonthlySummaryHandler : IRequestHandler<GetMonthlySummaryQuery, GetMonthlySummaryResponse>
    {
        private readonly IExpensesRepository _expensesRepository;
        private readonly IBudgetRepository _budgetRepository;

        public GetMonthlySummaryHandler(IExpensesRepository expensesRepository, IBudgetRepository budgetRepository)
        {
            _expensesRepository = expensesRepository;
            _budgetRepository = budgetRepository;
        }

        public async Task<GetMonthlySummaryResponse> Handle(GetMonthlySummaryQuery request, CancellationToken cancellationToken)
        {
           var totalSpent = await _expensesRepository.GetTotalForMonth(request.userId, request.Year, request.Month);

           var totalBudget = await _budgetRepository.GetTotalForMonth(request.userId, request.Year, request.Month);

            return new GetMonthlySummaryResponse
            {
                TotalSpent = totalSpent,
                TotalBudget = totalBudget
            };
        }
    }
}
