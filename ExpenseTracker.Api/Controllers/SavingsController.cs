using ExpenseTracker.Application.Savings.Command.CreateSavings;
using ExpenseTracker.Application.Savings.Queries.GetSavingsByMonth;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ExpenseTracker.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SavingsController : ControllerBase
    {
        private readonly IMediator _mediator;
        public SavingsController(IMediator mediator) => _mediator = mediator;



        [HttpPost("CreateSaving")]
        public async Task<IActionResult> Create([FromBody] CreateSavingsCommand command)
        {
            var id = await _mediator.Send(command);
            return Ok(new
            {
                Message = "Successfully Created New Saving",
                Result = id
            });
        }


        [HttpGet("month/{userId}/{year}/{month}")]
        public async Task<IActionResult> GetSavingsByMonth(int userId, int year, int month)
        {
            var query = new GetSavingsByMonthQuery(userId, year, month);
            var result = await _mediator.Send(query);
            if (result == null || !result.Any())
            {
                return NotFound("No Savings found for the specified period.");
            }
            return Ok(result);
        }
    }
}
