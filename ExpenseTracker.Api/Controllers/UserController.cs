using ExpenseTracker.Application.Users.Command.CreateUser;
using ExpenseTracker.Application.Users.Command.LoginUser;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ExpenseTracker.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IMediator _mediator;
        public UserController(IMediator mediator) => _mediator = mediator;

        [HttpPost("CreateUser")]
        public async Task<IActionResult> Create([FromBody] CreateUserCommand command)
        {
            var id = await _mediator.Send(command);
            return Ok(new
            {
                Message = "New User successfully created",
                UserId = id,
                CreatedAt = DateTime.Now
            });
        }

        [HttpPost("LoginUser")]
        public async Task<IActionResult> Login([FromBody] LoginUserCommand command)
        {
            var token = await _mediator.Send(command);
            return Ok(new
            {
                Message = token.ErrorMessage,
                JwtToken = token.Token,
                LoggedInAt = DateTime.Now
            });
        }
    }
}
