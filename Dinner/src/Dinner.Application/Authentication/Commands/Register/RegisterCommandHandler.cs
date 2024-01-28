using Dinner.Application.Authentication.Commands.Register;
using Dinner.Application.Authentication.Common;
using Dinner.Application.Common.Interfaces.Authentication;
using Dinner.Application.Common.Interfaces.Persistence;
using Dinner.Domain.Entities;
using ErrorOr;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dinner.Domain.Common.Errors;

namespace Dinner.Application.Authentication.Commands
{
    public class RegisterCommandHandler(
        IJwtTokenGenerator jwtTokenGenerator,
        IUserRepository userRepository) : IRequestHandler<RegisterCommand, ErrorOr<AuthenticationResult>>
    {
        private readonly IJwtTokenGenerator _jwtTokenGenerator = jwtTokenGenerator;
        private readonly IUserRepository _userRepository = userRepository;

        public async Task<ErrorOr<AuthenticationResult>> Handle(RegisterCommand request, CancellationToken cancellationToken)
        {
            await Task.CompletedTask;
            // Check if user already exists
            if (_userRepository.GetUserByEmail(request.Email) is not null)
            {
                return Errors.User.DuplicateEmail;
            }

            // Create user (generate unique ID)
            var user = new User
            {
                FirstName = request.FirstName,
                LastName = request.LastName,
                Email = request.Email,
                Password = request.Password
            };
            _userRepository.Add(user);

            // Create Jwt token
            var token = _jwtTokenGenerator.GenerateToken(user);
            return new AuthenticationResult(user, token);
        }
    }
}
