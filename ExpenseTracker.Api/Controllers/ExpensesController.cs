using ExpenseTracker.Application.Expenses.Commands.CreateExpense;
using ExpenseTracker.Application.Expenses.Queries.GetExpensesByMonth;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ExpenseTracker.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ExpensesController : ControllerBase
    {
        private readonly IMediator _mediator;
        public ExpensesController(IMediator mediator) => _mediator = mediator;

        [HttpPost("CreateExpense")]
        public async Task<IActionResult> Create([FromBody] CreateExpenseCommand command)
        {
            var id = await _mediator.Send(command);
            return Ok();
        }

        [HttpGet("month/{userId}/{year}/{month}")]
        public async Task<IActionResult> GetExpensesByMonth(int userId, int year, int month)
        {
            var query = new GetExpensesByMonthQuery(userId, year, month);

            var result = await _mediator.Send(query);
            if (result == null || !result.Any())
            {
                return NotFound("No Expenses found for the specified period.");
            }

            return Ok(result);


        }
    }
}
