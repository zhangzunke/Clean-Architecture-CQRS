using Dinner.Application.Services.Authentication;
using Dinner.Contracts.Authentication;
using Microsoft.AspNetCore.Mvc;

namespace Dinner.Api.Controllers
{
    [ApiController]
    [Route("auth")]
    public class AuthenticationController(IAuthenticationService authenticationService) : ApiController
    {
        private readonly IAuthenticationService _authenticationService = authenticationService;

        [HttpPost("register")]
        public IActionResult Register(RegisterRequest request)
        {
            var authResult = _authenticationService.Register(request.FirstName, request.LastName, request.Email, request.Password);

            return authResult.Match(
                authResult => Ok(MapAuthResult(authResult)),
                errors => Problem(errors));
        }

        [HttpPost("login")]
        public IActionResult Login(LoginRequest request) 
        {
            var authResult = _authenticationService.Login(request.Email, request.Password);
            return authResult.Match(
                authResult => Ok(MapAuthResult(authResult)),
                errors => Problem(errors));
        }

        private static AuthenticationResponse MapAuthResult(AuthenticationResult authResult)
        {
            return new AuthenticationResponse(
                authResult.User.Id,
                authResult.User.FirstName,
                authResult.User.LastName,
                authResult.User.Email,
                authResult.Token);
        }
    }
}
