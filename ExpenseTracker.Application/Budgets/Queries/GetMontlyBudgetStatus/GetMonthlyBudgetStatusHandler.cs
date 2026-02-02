using ExpenseTracker.Application.Common.Interfaces;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExpenseTracker.Application.Budgets.Queries.GetMontlyBudgetStatus
{
    public class GetMonthlyBudgetStatusHandler : IRequestHandler<GetMonthlyBudgetStatusQuery, List<GetMonthlyStatusResponse>>
    {
        private readonly IBudgetRepository _budgetRepository;

        public GetMonthlyBudgetStatusHandler(IBudgetRepository budgetRepository)
        {
            _budgetRepository = budgetRepository;
        }

        public async Task<List<GetMonthlyStatusResponse>> Handle(GetMonthlyBudgetStatusQuery request, CancellationToken cancellationToken)
        {
            var budget = await _budgetRepository
                .GetByUserAndMonth(request.UserId, request.Year, request.Month);

            var response = budget.Select(b => new GetMonthlyStatusResponse
            {
                Id = b.Id,
                Amount = b.Amount,
                Currency = b.Currency,
                Month = b.Month,
                CategoryId = b.CategoryId,
                Year = b.Year,
            }).ToList();   

            return response;
        }
    }
}
