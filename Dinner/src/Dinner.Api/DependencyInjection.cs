using Dinner.Api.Common.Errors;
using Dinner.Api.Common.Mapping;
using Mapster;
using MapsterMapper;
using Microsoft.AspNetCore.Mvc.Infrastructure;
using System.Reflection;

namespace Dinner.Api
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddPresentation(this IServiceCollection services)
        {
            services.AddMappings();
            // builder.Services.AddControllers(options => options.Filters.Add<ErrorHandlingFilterAttribute>());
            services.AddControllers();
            services.AddSingleton<ProblemDetailsFactory, DinnerProblemDetailsFactory>();
            // Add services to the container.
            services.AddAuthorization();
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            services.AddEndpointsApiExplorer();
            services.AddSwaggerGen();

            return services;
        }
    }
}
