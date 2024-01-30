
using Dinner.Api.Common.Errors;
using Dinner.Api.Filters;
using Dinner.Api.Middleware;
using Dinner.Application;
using Dinner.Infrastructure;
using Microsoft.AspNetCore.Mvc.Infrastructure;
using Microsoft.Extensions.DependencyInjection.Extensions;

namespace Dinner.Api
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);
            {
                builder.Services.AddPresentation()
                                .AddApplication()
                                .AddInfrastructure(builder.Configuration);
            }


            var app = builder.Build();
            {
                // Configure the HTTP request pipeline.
                if (app.Environment.IsDevelopment())
                {
                    app.UseSwagger();
                    app.UseSwaggerUI();
                }

                // app.UseMiddleware<ErrorHandlingMiddleware>();
                app.UseExceptionHandler("/error");
                app.UseHttpsRedirection();
                app.UseAuthentication();
                app.UseAuthorization();
                app.MapControllers();

                app.Run();
            }
        }
    }
}
