using Dinner.Application.Services.Authentication;
using Microsoft.Extensions.DependencyInjection;

namespace Dinner.Infrastructure
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddInfrastructure(this IServiceCollection services)
        {
            return services;
        }
    }
}
