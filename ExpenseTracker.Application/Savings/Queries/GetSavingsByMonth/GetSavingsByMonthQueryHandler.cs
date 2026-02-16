using ExpenseTracker.Application.Common.Interfaces;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExpenseTracker.Application.Savings.Queries.GetSavingsByMonth
{
    public class GetSavingsByMonthQueryHandler : IRequestHandler<GetSavingsByMonthQuery, List<GetSavingsByMonthQueryResponse>>
    {
        private readonly ISavingRepository _savingRepository;

        public GetSavingsByMonthQueryHandler(ISavingRepository savingRepository)
        {
            _savingRepository = savingRepository;
        }

        public async Task<List<GetSavingsByMonthQueryResponse>> Handle(GetSavingsByMonthQuery request, CancellationToken cancellationToken)
        {
            var savings = await _savingRepository.GetByUserAndMonth(request.userId, request.year, request.month);

            var response = savings.Select(s => new GetSavingsByMonthQueryResponse
            {
                Id = s.Id,
                Amount = s.Amount,
                Currency = s.Currency,
                Timestamp = s.Timestamp
            }).ToList();


            return response;

        }
    }
}
