using Dinner.Application.Authentication.Commands.Register;
using Dinner.Application.Authentication.Common;
using Dinner.Application.Authentication.Queries.Login;
using Dinner.Contracts.Authentication;
using Mapster;
using Microsoft.Win32;

namespace Dinner.Api.Common.Mapping
{
    public class AuthenticationMappingConfig : IRegister
    {
        public void Register(TypeAdapterConfig config)
        {
            config.NewConfig<LoginQuery, LoginRequest>();
            config.NewConfig<RegisterCommand, RegisterRequest>();

            config.NewConfig<AuthenticationResult, AuthenticationResponse>()
                .Map(dest => dest.Token, src => src.Token)
                .Map(dest => dest, src => src.User);
        }
    }
}
