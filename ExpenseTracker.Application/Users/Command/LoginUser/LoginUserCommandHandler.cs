using ExpenseTracker.Application.Common.Interfaces;
using ExpenseTracker.Application.Helper;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExpenseTracker.Application.Users.Command.LoginUser
{
    public class LoginUserCommandHandler : IRequestHandler<LoginUserCommand, LoginResult>
    {
        private readonly IUserRepository _userRepository;
        private readonly JwtTokenHelper _jwtTokenHelper;

        public LoginUserCommandHandler(IUserRepository userRepository, JwtTokenHelper jwtTokenHelper )
        {
            _userRepository = userRepository;
            _jwtTokenHelper = jwtTokenHelper;
        }

        public async Task<LoginResult> Handle(LoginUserCommand request, CancellationToken cancellationToken)
        {
          var user = await _userRepository.GetUserName(request.UserName, cancellationToken);

            if(user == null)
            {
                return LoginResult.Failure("Invalid username or password");
            }

            var isValid = await _userRepository.VerifyPasswordAsync(user, request.Password, cancellationToken);

            if(!isValid)
            {
                return LoginResult.Failure("Invalid username or password");
            }

            var token = await _jwtTokenHelper.GenerateJwtToken(user);

            return LoginResult.Success(token, user.Id, user.UserName);

        }
    }
}
