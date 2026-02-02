using ExpenseTracker.Application.Common.Interfaces;
using ExpenseTracker.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;

namespace ExpenseTracker.Application.Expenses.Commands.CreateExpense
{
    public class CreateExpenseCommandHandler : IRequestHandler<CreateExpenseCommand, int>
    {
        private readonly IExpensesRepository _expenseRepository;


        public CreateExpenseCommandHandler(IExpensesRepository expenseRepository)
        {
            _expenseRepository = expenseRepository;
        }

        public async Task<int> Handle(CreateExpenseCommand command, CancellationToken cancellationToken)
        {
            var expense = new Expense
            {
                UserId = command.UserId,
                Amount = command.Amount,
                Currency = command.Currency,
                IsRecurring = command.IsRecurring,
                CategoryId = command.CategoryId,
                ExpenseDate = command.ExpenseDate,
                Description = command.Description
            };

            await _expenseRepository.AddAsync(expense, cancellationToken);

            return expense.Id;  
        }
    }


}
