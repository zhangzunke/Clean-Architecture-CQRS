using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dinner.Application.Authentication.Common;
using ErrorOr;
using MediatR;

namespace Dinner.Application.Authentication.Queries.Login
{
    public record LoginQuery(string Email, string Password) : IRequest<ErrorOr<AuthenticationResult>>;
}
