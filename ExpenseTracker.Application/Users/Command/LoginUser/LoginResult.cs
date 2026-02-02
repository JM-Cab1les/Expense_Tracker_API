using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExpenseTracker.Application.Users.Command.LoginUser
{
    public class LoginResult
    {
        public bool IsSuccess { get; init; }
        public string Token { get; init; } = string.Empty;
        public int UserId { get; init; }
        public string Username { get; init; } = string.Empty;
        public string ErrorMessage { get; init; } = string.Empty;

        public static LoginResult Success(string token, int userId, string username)
            => new() { IsSuccess = true, Token = token, UserId = userId, Username = username };

        public static LoginResult Failure(string message)
            => new() { IsSuccess = false, ErrorMessage = message };
    }
}
