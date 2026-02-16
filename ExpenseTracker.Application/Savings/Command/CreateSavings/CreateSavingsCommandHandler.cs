using ExpenseTracker.Application.Common.Interfaces;
using ExpenseTracker.Infrastructure.Models;
using FluentValidation;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExpenseTracker.Application.Savings.Command.CreateSavings
{
    public class CreateSavingsCommandHandler : IRequestHandler<CreateSavingsCommand, int>
    {

        private readonly ISavingRepository _savingsRepository;

        public CreateSavingsCommandHandler(ISavingRepository savingsRepository)
        {
            _savingsRepository = savingsRepository;
        }

        public async Task<int> Handle(CreateSavingsCommand request, CancellationToken cancellationToken)
        {
           var savings = new Saving
           {
                UserId = request.UserId,
                Amount = request.Amount,
                Currency = request.Currency,
                Year = request.Year,
                Month = request.Month
           };
            await _savingsRepository.AddAsync(savings, cancellationToken);

            return savings.Id;
        }
    }
}
