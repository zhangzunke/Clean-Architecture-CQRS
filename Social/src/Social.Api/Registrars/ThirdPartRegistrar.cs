
using MediatR;
using Microsoft.AspNetCore.Hosting;
using Social.Application.UserProfiles.Queries;

namespace Social.Api.Registrars
{
    public class ThirdPartRegistrar : IWebApplicationBuilderRegistrar
    {
        public void RegisterServices(WebApplicationBuilder builder)
        {
            builder.Services.AddAutoMapper(typeof(Program), typeof(GetAllUserProfiles));
            builder.Services.AddMediatR(config => 
            {
                config.RegisterServicesFromAssemblies(AppDomain.CurrentDomain.GetAssemblies());
            });
        }
    }
}
