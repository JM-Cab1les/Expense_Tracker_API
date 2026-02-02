using ExpenseTracker.Application.Reports.Queries.GetMonthlySummaryQuery;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ExpenseTracker.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ReportController : ControllerBase
    {
        private readonly IMediator _mediator;
        public ReportController(IMediator mediator) => _mediator = mediator;



        [HttpGet("MonthlySummaryReport/{userId}/{year}/{month}")]
        public async Task<IActionResult> GetMonthlyBudgetSummary(int userId, int year, int month)
        {
            var query = new GetMonthlySummaryQuery(userId, year, month);
            var result = await _mediator.Send(query);
            if (result == null)
            {
                return NotFound("No data found for the specified period.");
            }
            return Ok(result);
        }

    }
}
