using Dinner.Application.Common.Interfaces.Authentication;
using Dinner.Application.Common.Interfaces.Persistence;
using Dinner.Domain.Common.Errors;
using Dinner.Domain.Entities;
using ErrorOr;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dinner.Application.Services.Authentication
{
    public class AuthenticationService(IJwtTokenGenerator jwtTokenGenerator, IUserRepository userRepository) : IAuthenticationService
    {
        private readonly IJwtTokenGenerator _jwtTokenGenerator = jwtTokenGenerator;
        private readonly IUserRepository _userRepository = userRepository;

        public ErrorOr<AuthenticationResult> Login(string email, string password)
        {
            if (_userRepository.GetUserByEmail(email) is not User user)
            {
                return Errors.Authentication.InvalidCredentials;
            }

            if (user.Password != password)
            {
                return Errors.Authentication.InvalidCredentials;
            }

            var token = _jwtTokenGenerator.GenerateToken(user);
            return new AuthenticationResult(user, token);
        }

        public ErrorOr<AuthenticationResult> Register(string firstName, string lastName, string email, string password)
        {
            // Check if user already exists
            if (_userRepository.GetUserByEmail(email) is not null)
            {
                return Errors.User.DuplicateEmail;
            }

            // Create user (generate unique ID)
            var user = new User
            {
                FirstName = firstName,
                LastName = lastName,
                Email = email,
                Password = password
            };
            _userRepository.Add(user);

            // Create Jwt token
            var token = _jwtTokenGenerator.GenerateToken(user);
            return new AuthenticationResult(user, token);
        }
    }
}
