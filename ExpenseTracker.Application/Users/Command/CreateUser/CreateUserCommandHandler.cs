using ExpenseTracker.Application.Common.Interfaces;
using ExpenseTracker.Application.Helper;
using ExpenseTracker.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExpenseTracker.Application.Users.Command.CreateUser
{
    public class CreateUserCommandHandler : IRequestHandler<CreateUserCommand, int>
    {
        private readonly IUserRepository _userRepository;
        public CreateUserCommandHandler(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }
        public async Task<int> Handle(CreateUserCommand request, CancellationToken cancellationToken)

        {

           var newuser = new User
           { 
                 UserName = request.UserName,
                 Password = PasswordHasHelper.HashPassword(request.Password),
                 FirstName = request.FirstName,
                 LastName = request.LastName
           };

            await _userRepository.AddAsync(newuser, cancellationToken);
            return newuser.Id;
        }
    }
}
