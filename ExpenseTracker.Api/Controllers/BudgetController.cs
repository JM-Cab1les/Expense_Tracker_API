using ExpenseTracker.Application.Budgets.Command.CreateBudget;
using ExpenseTracker.Application.Budgets.Queries.GetMontlyBudgetStatus;
using ExpenseTracker.Application.Expenses.Commands.CreateExpense;
using ExpenseTracker.Application.Expenses.Queries.GetExpensesByMonth;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ExpenseTracker.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BudgetController : ControllerBase
    {
        private readonly IMediator _mediator;
        public BudgetController(IMediator mediator) => _mediator = mediator;


        [HttpPost("CreateBudget")]
        public async Task<IActionResult> Create([FromBody] CreateBudgetCommand command)
        {
            var id = await _mediator.Send(command);
            return Ok(new
            {
                Message = "Successfully Created New Budget",
                Result = id
            });
        }

        [HttpGet("month/{userId}/{year}/{month}")]
        public async Task<IActionResult> GetBudgetByMonth(int userId, int year, int month)
        {
            var query = new GetMonthlyBudgetStatusQuery(userId, year, month);

            var result = await _mediator.Send(query);
            if (result == null || !result.Any())
            {
                return NotFound("No Budget found for the specified period.");
            }

            return Ok(result);


        }
    }
}
