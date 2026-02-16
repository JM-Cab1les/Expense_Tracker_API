using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExpenseTracker.Application.Savings.Command.CreateSavings
{
    public class CreateCommandValidator : AbstractValidator<CreateSavingsCommand>
    {
        public CreateCommandValidator()
        {
            RuleFor(x => x.UserId).NotEmpty();
            RuleFor(x => x.Amount).GreaterThan(0);
            RuleFor(x => x.Currency).NotEmpty().Length(3);
            RuleFor(x => x.Year).GreaterThan(0);
            RuleFor(x => x.Month).GreaterThan(0);
        }
    }
}
