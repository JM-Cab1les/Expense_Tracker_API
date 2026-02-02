using ExpenseTracker.Application.Common.Interfaces;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExpenseTracker.Application.Expenses.Queries.GetExpensesByMonth
{
    public class GetExpensesByMonthQueryHandler
        : IRequestHandler<GetExpensesByMonthQuery, List<GetExpenseByMonthQueryResponse>>
    {
        private readonly IExpensesRepository _expensesRepository;

        public GetExpensesByMonthQueryHandler(IExpensesRepository expensesRepository)
        {
            _expensesRepository = expensesRepository;
        }
        public async Task<List<GetExpenseByMonthQueryResponse>> Handle(GetExpensesByMonthQuery request, CancellationToken ct)
        {
           var expenses = await _expensesRepository
                .GetByUserAndMonth(request.userId, request.year, request.month);


           var response = expenses.Select(e => new GetExpenseByMonthQueryResponse
           {
               Id = e.Id,
               Amount = e.Amount,
               Currency = e.Currency,
               ExpenseDate = e.ExpenseDate,
               IsRecurring = e.IsRecurring ?? false,
               Description = e.Description
           }).ToList();

            return response;
        }
    }
}
