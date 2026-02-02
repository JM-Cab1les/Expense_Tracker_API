using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExpenseTracker.Application.Expenses.Commands.CreateExpense
{
   public class CreateExpenseCommandValidator : AbstractValidator<CreateExpenseCommand>
    {
        public CreateExpenseCommandValidator() {

            RuleFor(x => x.UserId).NotEmpty();
            RuleFor(x => x.Amount).GreaterThan(0);
            RuleFor(x => x.Currency).NotEmpty().Length(3);
            RuleFor(x => x.CategoryId).NotEmpty();
            RuleFor(x => x.ExpenseDate).LessThanOrEqualTo(DateTime.UtcNow);
            RuleFor(x => x.Description).MaximumLength(255);
        }
    }
}
