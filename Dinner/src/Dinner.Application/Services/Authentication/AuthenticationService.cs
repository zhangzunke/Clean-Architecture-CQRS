using Dinner.Application.Common.Interfaces.Authentication;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dinner.Application.Services.Authentication
{
    public class AuthenticationService(IJwtTokenGenerator jwtTokenGenerator) : IAuthenticationService
    {
        private readonly IJwtTokenGenerator _jwtTokenGenerator = jwtTokenGenerator;

        public AuthenticationResult Login(string email, string password)
        {
            return new AuthenticationResult(Guid.NewGuid(), "Mike", "Zhang", email, "token");
        }

        public AuthenticationResult Register(string firstName, string lastName, string email, string password)
        {
            // Check if user already exists

            // Create user (generate unique ID)

            // Create Jwt token
            var userId = Guid.NewGuid();
            var token = _jwtTokenGenerator.GenerateToken(userId, firstName, lastName);
            return new AuthenticationResult(userId, firstName, lastName, email, token);
        }
    }
}
