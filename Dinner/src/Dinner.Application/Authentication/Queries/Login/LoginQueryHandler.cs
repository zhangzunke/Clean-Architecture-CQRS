using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dinner.Application.Authentication.Common;
using Dinner.Application.Common.Interfaces.Authentication;
using Dinner.Application.Common.Interfaces.Persistence;
using Dinner.Domain.Entities;
using Dinner.Domain.Common.Errors;
using ErrorOr;
using MediatR;

namespace Dinner.Application.Authentication.Queries.Login
{
    public class LoginQueryHandler(
        IJwtTokenGenerator jwtTokenGenerator,
        IUserRepository userRepository)
        : IRequestHandler<LoginQuery, ErrorOr<AuthenticationResult>>
    {
        private readonly IJwtTokenGenerator _jwtTokenGenerator = jwtTokenGenerator;
        private readonly IUserRepository _userRepository = userRepository;

        public async Task<ErrorOr<AuthenticationResult>> Handle(LoginQuery request, CancellationToken cancellationToken)
        {
            await Task.CompletedTask;

            if (_userRepository.GetUserByEmail(request.Email) is not User user)
            {
                return Errors.Authentication.InvalidCredentials;
            }

            if (user.Password != request.Password)
            {
                return Errors.Authentication.InvalidCredentials;
            }

            var token = _jwtTokenGenerator.GenerateToken(user);
            var authenticationResult = new AuthenticationResult(user, token);

            return authenticationResult;
        }
    }
}
